using Dapper;
using Dataplace.Core.Infra.Data.SqlConnection;
using Dataplace.Core.Shared.Catalog.Produto.Queries;
using Dataplace.Core.Shared.Catalog.Produto.ViewModels;
using dpLibrary05;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Dataplace.Core.Domain.Query;

namespace Dataplace.Imersao.Core.Application.Produtos.Queries
{
    public class ProdutoSerachQueryHandler :
      IRequestHandler<ProdutoSearchQuery, IEnumerable<ProdutoSearchModel>>,
      IRequestHandler<ProdutoVariacaoSearchQuery, IEnumerable<ProdutoSearchModel>>,
      IRequestHandler<ProdutoGradeSearchQuery, IEnumerable<ProdutoSearchModel>>
    {

        private readonly IDataAccess _dataAccess;
        public ProdutoSerachQueryHandler(ISqlDataAccess sqlDataAccess)
        {
            _dataAccess = sqlDataAccess;
        }

        #region Handlers
        public async Task<IEnumerable<ProdutoSearchModel>> Handle(ProdutoSearchQuery query, CancellationToken c)
        {
            var sql = query.BarCode ?
                GetProdutoSearchBarcode() :
                GetProdutoSearchNotBarcode();

            var cmd = new CommandDefinition(sql.ToString(), new { query.Term }, flags: CommandFlags.NoCache);
            return await _dataAccess.Connection.QueryAsync<ProdutoSearchModel>(cmd);
        }

        public  async Task< IEnumerable<ProdutoSearchModel>> Handle(ProdutoVariacaoSearchQuery query, CancellationToken c )
        {
            var sql = @"
                select distinct t.*, p.dsvenda as dsItem, p.unidade, p.origem, p.stativo, p.stativo02, p.stativo03, case t.type when 1 then p.cdbarra else t.id end as cdbarra, p.cdcest , p.status, p.StOpcional from 
                (
	                select 
		                1 as type
		                ,ProdutoCombinacao.cdproduto as id				
		                ,ProdutoCombinacao.cdprodutoVariacao as cdItem
		                ,ProdutoCombinacao.tpRegistroVariacao as tpItem
		                ,ProdutoVariacao.stTpControle as stTpControle 
			            ,null as qtditem
			            ,null as qtdvolume 
			            from ProdutoCombinacao
			            inner join ProdutoVariacao on ProdutoVariacao.cdempresa =  ProdutoCombinacao.cdempresa 
				            and ProdutoVariacao.cdfilial =  ProdutoCombinacao.cdfilial 
				            and ProdutoVariacao.tpregistro =  ProdutoCombinacao.tpRegistroVariacao 
				            and ProdutoVariacao.cdproduto =  ProdutoCombinacao.cdprodutoVariacao
                ) as t
                INNER JOIN SYM_find_Produto as p
		            ON p.TpProduto = t.tpItem 
			            AND p.cdproduto = t.cdItem
		
                where t.id = @Term
                ";
            return await _dataAccess.Connection.QueryAsync<ProdutoSearchModel>(sql, new { query.Term });
        }

        public async Task<IEnumerable<ProdutoSearchModel>> Handle(ProdutoGradeSearchQuery query, CancellationToken c)
        {
            var sql = $@"
				{ProdutoGradeDescricao}

				select distinct 
					 t.type
					,t.id
					,t.cdproduto as cdItem
					,t.tpProduto as tpItem
					,t.stTpControle
					,t.qtditem
					,t.qtdvolume
					,p.dsvenda + t.dsGrade as dsItem
					, p.unidade, p.origem, p.stativo, p.stativo02, p.stativo03, case t.type when 1 then p.cdbarra else t.id end as cdbarra, p.cdcest , p.status, p.StOpcional 
					,t.cdgrade, t.cdEixoX, t.cdRespostaX, t.cdEixoY, t.cdRespostaY
	
					from 
				(
					select 
						 1 as type
						,ProdutoGrade.cdproduto as id				
						,ProdutoGrade.cdproduto as cdProduto
						,ProdutoGrade.tpProduto as tpProduto
						,Produto.stTpControle as stTpControle 
						,null as qtditem
						,null as qtdvolume
						,ProdutoGrade.dsProduto as dsGrade
						,ProdutoGrade.cdgrade
						,ProdutoGrade.cdEixoX
						,ProdutoGrade.cdEixoY
						,ProdutoGrade.cdRespostaX
						,ProdutoGrade.cdRespostaY
						from ProdutoGradeDescricao as ProdutoGrade
						inner join Produto on Produto.cdempresa =  ProdutoGrade.cdempresa 
							and Produto.cdfilial =  ProdutoGrade.cdfilial 
							and Produto.TpProduto =  ProdutoGrade.tpProduto 
							and Produto.cdproduto =  ProdutoGrade.cdproduto

				) as t
				INNER JOIN SYM_find_Produto as p
					ON p.TpProduto = t.TpProduto 
						AND p.cdproduto = t.cdProduto
		
                where t.id = @Term
                ";

            return await _dataAccess.Connection.QueryAsync<ProdutoSearchModel, ProdutoGradeModel, ProdutoSearchModel>(sql, (p, g) =>
            {

                if (g != null)
                    p.Grade = g;

                return p;
            }, new { query.Term }, splitOn: "cdgrade");

        }

        #endregion

        #region Internal Methods

        // internas

        private const string ProdutoGradeDescricao = @"
		WITH ProdutoGradeDescricao (cdEmpresa, cdFilial, cdProduto, tpProduto, dsProduto, cdgrade, cdEixoX, cdEixoY, cdRespostaX, cdRespostaY)  
		AS  
		(  
				select 			
					 ProdutoGrade.cdEmpresa as cdEmpresa
					,ProdutoGrade.cdFilial as cdFilial
					,ProdutoGrade.cdproduto as cdProduto
					,ProdutoGrade.tpregistro as tpProduto
					, 
					case when isnull(ProdutoGrade.cdeixox,'0') = '0' and isnull(ProdutoGrade.cdeixoy,'0') = '0' then 
						'' 
						else 
						' - ' 
							+ 
							case when isnull(ProdutoGrade.cdeixox,'0') = '0' then 
							'' 
							else 
								rtrim(EixoX.dseixo) + ': ' + rtrim(EixoRespostaX.DsResposta) 
							end 
							+ 
							case when isnull(ProdutoGrade.cdeixox,'0') <> '0' and isnull(ProdutoGrade.cdeixox,'0') <> '0' then 
							'; ' 
							else 
								''
							end 
							+
							case when isnull(ProdutoGrade.cdeixoy,'0') = '0' then 
							'' 
							else 
								rtrim(EixoY.dseixo) + ': ' + rtrim(EixoRespostaY.DsResposta) 
							end 
					end as dsProduto
					,ProdutoGrade.cdgrade
					,ProdutoGrade.cdeixox 
					,ProdutoGrade.cdeixoy 
					,ProdutoGrade.cdrespostax 
					,ProdutoGrade.cdrespostay
					from ProdutoGrade
					inner join Eixo as EixoX on EixoX.cdeixo =  ProdutoGrade.cdeixox 
						and EixoX.CdEmpresa =  ProdutoGrade.CdEmpresa 
						and EixoX.CdFilial =  ProdutoGrade.CdFilial 
					inner join Eixo as EixoY on EixoY.cdeixo =  ProdutoGrade.cdeixoy 
						and EixoY.CdEmpresa =  ProdutoGrade.CdEmpresa 
						and EixoY.CdFilial =  ProdutoGrade.CdFilial 
					inner join EixoResposta as EixoRespostaX on EixoRespostaX.cdeixo =  ProdutoGrade.cdeixox and EixoRespostaX.CdResposta =  ProdutoGrade.cdrespostax 
						and EixoRespostaX.CdEmpresa =  ProdutoGrade.CdEmpresa 
						and EixoRespostaX.CdFilial =  ProdutoGrade.CdFilial 
					inner join EixoResposta as EixoRespostaY on EixoRespostaY.cdeixo =  ProdutoGrade.cdeixoy and EixoRespostaY.CdResposta =  ProdutoGrade.cdrespostay 
						and EixoRespostaY.CdEmpresa =  ProdutoGrade.CdEmpresa 
						and EixoRespostaY.CdFilial =  ProdutoGrade.CdFilial  
)  
		";

        private StringBuilder GetProdutoSearchNotBarcode()
        {
            var queryString = new StringBuilder();
            queryString.AppendLine("select distinct t.*,")
                .AppendLine("	p.dsvenda as dsItem,")
                .AppendLine("	p.unidade,")
                .AppendLine("	p.origem,")
                .AppendLine("	p.stativo,")
                .AppendLine("	p.stativo02,")
                .AppendLine("	p.stativo03,")
                .AppendLine("	case t.type when 1 then p.cdbarra else t.id end as cdbarra, ")
                .AppendLine("	p.cdcest, ")
                .AppendLine("	p.status, ")
                .AppendLine("	p.StOpcional  ")
                .AppendLine("	FROM")
                .AppendLine("(")
                .AppendLine("    select ")
                .AppendLine("         1 as type")
                .AppendLine("        ,cdProduto as id				")
                .AppendLine("        ,cdProduto as cdItem")
                .AppendLine("        ,produto.tpProduto as tpItem")
                .AppendLine("        ,produto.stTpControle ")
                .AppendLine("		,null as multiploQtdItem")
                .AppendLine("		,null as multiploQtdVolume")
                .AppendLine("        ,null as multiploCdUnidadeVolume from produto	")
                .AppendLine("    union all")
                .AppendLine("    select ")
                .AppendLine("         3 as type")
                .AppendLine("        ,cdservico as id				")
                .AppendLine("        ,cdservico as cdItem")
                .AppendLine("        ,Servico.tpservico")
                .AppendLine("        ,0 as stTpControle ")
                .AppendLine("		,null as multiploQtdItem")
                .AppendLine("		,null as multiploQtdVolume")
                .AppendLine("        ,null as multiploCdUnidadeVolume from Servico	")
                .AppendLine(") as t")
                .AppendLine("INNER JOIN SYM_find_Produto as p")
                .AppendLine("    ON p.TpProduto = t.tpItem ")
                .AppendLine("        AND p.cdproduto = t.cdItem")
                .AppendLine("where t.id = @Term");

            return queryString;

        }

        private StringBuilder GetProdutoSearchBarcode()
        {
            var queryString = new StringBuilder();
            queryString.AppendLine("select distinct t.*,")
                .AppendLine("	p.dsvenda as dsItem,")
                .AppendLine("	p.unidade,")
                .AppendLine("	p.origem,")
                .AppendLine("	p.stativo,")
                .AppendLine("	p.stativo02,")
                .AppendLine("	p.stativo03,")
                .AppendLine("	case t.type when 1 then p.cdbarra else t.id end as cdbarra, ")
                .AppendLine("	p.cdcest , ")
                .AppendLine("	p.status, ")
                .AppendLine("	p.StOpcional  ")
                .AppendLine("FROM ")
                .AppendLine("(")
                .AppendLine("    select ")
                .AppendLine("         1 as type")
                .AppendLine("        ,cdProduto as id				")
                .AppendLine("        ,cdProduto as cdItem")
                .AppendLine("        ,produto.tpProduto as tpItem")
                .AppendLine("        ,produto.stTpControle ")
                .AppendLine("		,null as multiploQtdItem")
                .AppendLine("		,null as multiploQtdVolume")
                .AppendLine("        ,null as multiploCdUnidadeVolume from produto		")
                .AppendLine("    union all")
                .AppendLine("    select ")
                .AppendLine("         3 as type")
                .AppendLine("        ,cdservico as id				")
                .AppendLine("        ,cdservico as cdItem")
                .AppendLine("        ,Servico.tpservico as tpItem")
                .AppendLine("        ,0 as stTpControle ")
                .AppendLine("		,null as multiploQtdItem")
                .AppendLine("		,null as multiploQtdVolume")
                .AppendLine("        ,null as multiploCdUnidadeVolume from Servico	")
                .AppendLine("    union all")
                .AppendLine("    select ")
                .AppendLine("         1 as type")
                .AppendLine("        ,cdBarra as id					")
                .AppendLine("        ,cdProduto as cdItem")
                .AppendLine("        ,produto.tpProduto as tpItem")
                .AppendLine("        ,produto.stTpControle ")
                .AppendLine("		,null as multiploQtdItem")
                .AppendLine("		,null as multiploQtdVolume")
                .AppendLine("        ,null as multiploCdUnidadeVolume from produto				")
                .AppendLine("    union all")
                .AppendLine("    select ")
                .AppendLine("         2 as type")
                .AppendLine("        ,cdBarraMultiplo as id			")
                .AppendLine("        ,qtdlabelmultiplo.cdProduto as cdItem")
                .AppendLine("        ,produto.tpProduto as tpItem")
                .AppendLine("        ,produto.stTpControle ")
                .AppendLine("		,qtdlabelmultiplo.qtditem as multiploQtdItem")
                .AppendLine("		,qtdlabelmultiplo.qtdvolume as multiploQtdVolume")
                .AppendLine("        ,qtdlabelmultiplo.cdunidadevolume as multiploCdUnidadeVolume from qtdlabelmultiplo")
                .AppendLine("        INNER JOIN produto on produto.CdProduto = qtdlabelmultiplo.cdproduto and produto.CdEmpresa = qtdlabelmultiplo.cdempresa and produto.CdFilial = qtdlabelmultiplo.CdFilial")
                .AppendLine(") as t")
                .AppendLine("INNER JOIN SYM_find_Produto as p")
                .AppendLine("    ON p.TpProduto = t.tpItem ")
                .AppendLine("        AND p.cdproduto = t.cdItem")
                .AppendLine("")
                .AppendLine("where t.id = @Term");

            return queryString;
        }
        #endregion
    }
}
