using Dataplace.Core.Infra.Data.OdbcConnection;
using Dataplace.Imersao.Core.Domain.Orcamentos;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using dpLibrary05;
using Dapper;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using System.Linq;
using System.Collections.Generic;

namespace Dataplace.Imersao.Core.Infra.Data.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        #region fields
        private readonly IDataAccess _dataAccess = null;
        #endregion
        #region constructors
        public OrcamentoRepository(IOdbcDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        #endregion

        #region orcamento
        public int? AdicionarOrcamento(Orcamento entity)
        {
            var sql = @"
            INSERT INTO 
                Orcamento(DtOrcamento,VlVendar,DtFechamento,StOrcamento,CdCliente,NumDias,DtValidade,SqTabela,CdTabela,CdVendedor,Usuario,CdEmpresa,CdFilial)
            VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)

            SELECT SCOPE_IDENTITY()
            ";

            var result =  _dataAccess.Connection.ExecuteScalar<int?>(sql,
                new
                {
                    DtOrcamento = entity.DtOrcamento,
                    VlVendar = entity.ValotTotal,
                    DtFechamento = entity.DtFechamento,
                    StOrcamento = entity.Situacao.ToDataValue(),
                    CdCliente = entity.Cliente?.Codigo,
                    NumDias = entity.Validade?.Dias,
                    DtValidade = entity.Validade?.Data,
                    SqTabela = entity.TabelaPreco?.SqTabela,
                    CdTabela = entity.TabelaPreco?.CdTabela,
                    CdVendedor = entity.Vendedor?.Codigo,
                    Usuario = entity.Usuario?.UserName,
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                },
                transaction: _dataAccess.Transaction);

            return result;

        }
        public bool AtualizarOrcamento(Orcamento entity)
        {
            var sql = @"
            UPDATE 
                Orcamento
            SET
                 Orcamento.DtOrcamento = ?
                ,Orcamento.VlVendar = ?
                ,Orcamento.DtFechamento = ?
                ,Orcamento.StOrcamento = ?
                ,Orcamento.CdCliente = ?
                ,Orcamento.NumDias = ?
                ,Orcamento.DtValidade = ?
                ,Orcamento.SqTabela = ?
                ,Orcamento.CdTabela = ?
                ,Orcamento.CdVendedor = ?
                ,Orcamento.Usuario = ?
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

           return  _dataAccess.Connection.Execute(sql, 
               new {
                 
                   DtOrcamento = entity.DtOrcamento,
                   VlVendar = entity.ValotTotal,
                   DtFechamento = entity.DtFechamento,
                   StOrcamento = entity.Situacao.ToDataValue(),
                   CdCliente = entity.Cliente?.Codigo,
                   NumDias = entity.Validade?.Dias,
                   DtValidate = entity.Validade?.Data,
                   SeqTabela = entity.TabelaPreco?.SqTabela,
                   CdTabela = entity.TabelaPreco?.CdTabela,
                   CdVendedor = entity.Vendedor?.Codigo,
                   Usuario = entity.Usuario?.UserName,  
                   CdEmpresa = entity.CdEmpresa,
                   CdFilial = entity.CdFilial,
                   NumOrcamento = entity.NumOrcamento
               },
               transaction: _dataAccess.Transaction) > 0 ;


        }
        public bool ExcluirOrcamento(Orcamento entity)
        {
            var sql = @"
            DELETE FROM Orcamento
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

            return _dataAccess.Connection.Execute(sql,
                new
                {
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                    NumOrcamento = entity.NumOrcamento
                },
                transaction: _dataAccess.Transaction) > 0;
        }
        public Orcamento ObterOrcamento(string cdEmpresa, string cdFilial, int numOrcamento)
        {
            var sql = @"
            SELECT 
                 Orcamento.CdEmpresa
                ,Orcamento.CdFilial
                ,Orcamento.NumOrcamento        
                ,Orcamento.DtOrcamento 
                ,Orcamento.VlVendar as ValorTotal
                ,Orcamento.DtFechamento
                ,CASE Orcamento.StOrcamento WHEN 'P' THEN 0 WHEN 'F' THEN 1 WHEN 'C' THEN 2 END as Situacao
                ,null as Cliente
                ,Orcamento.CdCliente as Codigo
                ,Orcamento.NumDias
                ,Orcamento.DtValidade
                ,Orcamento.SqTabela
                ,Orcamento.CdTabela
                ,Orcamento.CdVendedor
                ,null as Vendedor
                ,Orcamento.CdVendedor as Codigo
                ,Orcamento.Usuario as UserName
            FROM
                Orcamento
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

            var items =  _dataAccess.Connection.Query<Orcamento, OrcamentoCliente, OrcamentoValidade, OrcamentoTabelaPreco, OrcamentoVendedor, OrcamentoUsuario, Orcamento>(sql, 
                (o, cli, val, tp, v, u) => {

                    if (cli != null)
                        o.DefinirCliente(cli);

                    if (val != null)
                        o.DefinirValidade(val);

                    if (tp != null)
                        o.DefinirTabelaPreco(tp);

                    if (v != null)
                        o.DefinirVendedor(v);

                    if (u != null)
                        o.DefinirUsuario(u);

                    return o;
                },
                new
                {
                    CdEmpresa = cdEmpresa,
                    CdFilial = cdFilial,
                    NumOrcamento = numOrcamento
                },
                splitOn: "CdEmpresa, Cliente, NumDias, SqTabela, Vendedor, UserName",
                transaction: _dataAccess.Transaction);


            return items.FirstOrDefault();
        }
        public Orcamento ObterOrcamentoComItems(string cdEmpresa, string cdFilial, int numOrcamento)
        {
            var sql = @"
            SELECT 
                 Orcamento.CdEmpresa
                ,Orcamento.CdFilial
                ,Orcamento.NumOrcamento        
                ,Orcamento.DtOrcamento 
                ,Orcamento.VlVendar as ValorTotal
                ,Orcamento.DtFechamento
                ,CASE Orcamento.StOrcamento WHEN 'P' THEN 0 WHEN 'F' THEN 1 WHEN 'C' THEN 2 END as Situacao
                ,null as Cliente
                ,Orcamento.CdCliente as Codigo
                ,Orcamento.NumDias
                ,Orcamento.DtValidade
                ,Orcamento.SqTabela
                ,Orcamento.CdTabela
                ,Orcamento.CdVendedor
                ,null as Vendedor
                ,Orcamento.CdVendedor as Codigo
                ,Orcamento.Usuario as UserName
                
            FROM
                Orcamento
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
            ";

            //LEFT JOIN
            //    OrcamentoItem
            //        ON OrcamentoItem.NumOrcamento = Orcamento.NumOrcamento
            //            AND OrcamentoItem.CdEmpresa = Orcamento.CdEmpresa
            //            AND OrcamentoItem.CdFilial = Orcamento.CdFilial


            var items = _dataAccess.Connection.Query<Orcamento, OrcamentoCliente, OrcamentoValidade, OrcamentoTabelaPreco, OrcamentoVendedor, OrcamentoUsuario, Orcamento>(sql,
                (o, cli, val, tp, v, u) => {

                    if (cli != null)
                        o.DefinirCliente(cli);

                    if (val != null)
                        o.DefinirValidade(val);

                    if (tp != null)
                        o.DefinirTabelaPreco(tp);

                    if (v != null)
                        o.DefinirVendedor(v);

                    if (u != null)
                        o.DefinirUsuario(u);

                    return o;
                },
                new
                {
                    CdEmpresa = cdEmpresa,
                    CdFilial = cdFilial,
                    NumOrcamento = numOrcamento
                },
                splitOn: "CdEmpresa, Cliente, NumDias, SqTabela, Vendedor, UserName",
                transaction: _dataAccess.Transaction);


            var item =  items.FirstOrDefault();
            if (item != null)
                item.DefinirItens(this.ObterItems(item.CdEmpresa , item.CdFilial , item.NumOrcamento).ToList());

            return item;
        }
        #endregion


        #region items
        public int? AdicionarItem(OrcamentoItem entity)
        {
            //var sql = @"
            //INSERT INTO 
            //   OrcamentoItem(CdEmpresa, CdFilial, NumOrcamento, qtdproduto, stitem, tpregistro, cdproduto, vlvenda, percaltpreco, vlcalculado)
            //VALUES(?,?,?,?,?,?,?,?,?,?)

            //SELECT Seq, CdEmpresa, CdFilial, NumOrcamento, qtdproduto, stitem, tpregistro as TpProduto, cdproduto, vlvenda as PrecoTabela, vlcalculado as PrecoVenda, percaltpreco as PercAltPreco
            //    FROM  
            //OrcamentoItem
            //    WHERE seq = (SELECT SCOPE_IDENTITY())
            //";
            //var items = _dataAccess.Connection.Query<OrcamentoItem, OrcamentoProduto, OrcamentoItemPreco, OrcamentoItem>(sql,
            //    (item, produto, preco) => {

            //        if (produto != null)
            //            item.DefinirProduto(produto);

            //        if (preco != null)
            //            item.DefinirPreco(preco);

            //        return item;
            //    },
            //    new
            //    {
            //        CdEmpresa = entity.CdEmpresa,
            //        CdFilial = entity.CdFilial,
            //        NumOrcamento = entity.NumOrcamento,
            //        qtdproduto = entity.Quantidade,
            //        stitem = entity.Situacao.ToDataValue(),
            //        tpregistro = entity.Produto.TpProduto.ToDataValue(),
            //        cdproduto = entity.Produto.CdProduto,
            //        vlvenda = entity.Preco?.PrecoTabela,
            //        percaltpreco = entity.Preco?.PercAltPreco,
            //        vlcalculado = entity.Preco?.PrecoVenda
            //    },
            //     splitOn : "TpProduto, PrecoTabela",
            //     transaction: _dataAccess.Transaction); 
            //return items.FirstOrDefault();










            var sql = @"
            INSERT INTO 
               OrcamentoItem(CdEmpresa, CdFilial, NumOrcamento, qtdproduto, stitem, tpregistro, cdproduto, vlvenda, percaltpreco, vlcalculado)
            VALUES(?,?,?,?,?,?,?,?,?,?);

            SELECT SCOPE_IDENTITY()
            ";
            var result = _dataAccess.Connection.ExecuteScalar<int?>(sql,
                new
                {
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                    NumOrcamento = entity.NumOrcamento,
                    qtdproduto = entity.Quantidade,
                    stitem = entity.Situacao.ToDataValue(),
                    tpregistro = entity.Produto.TpProduto.ToDataValue(),
                    cdproduto = entity.Produto.CdProduto,
                    vlvenda = entity.Preco?.PrecoTabela,
                    percaltpreco = entity.Preco?.PercAltPreco,
                    vlcalculado = entity.Preco?.PrecoVenda
                },
                 transaction: _dataAccess.Transaction);

            return result;

        }

        public bool AtualizarItem(OrcamentoItem entity)
        {
            var sql = @"
            UPDATE 
                OrcamentoItem
            SET
                qtdproduto= ?, stitem= ?, tpregistro= ?, cdproduto= ?, vlvenda= ?, percaltpreco= ?, vlcalculado= ?
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
                AND Seq = ?
            ";
            return _dataAccess.Connection.Execute(sql,
                new
                {

                    qtdproduto = entity.Quantidade,
                    stitem = entity.Situacao.ToDataValue(),
                    tpregistro = entity.Produto.TpProduto.ToDataValue(),
                    cdproduto = entity.Produto.CdProduto,
                    vlvenda = entity.Preco?.PrecoTabela,
                    percaltpreco = entity.Preco?.PercAltPreco,
                    vlcalculado = entity.Preco?.PrecoVenda,
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                    NumOrcamento = entity.NumOrcamento,
                    Seq = entity.Seq,
                },
                transaction: _dataAccess.Transaction) > 0;
        }

        public bool ExcluirItem(OrcamentoItem entity)
        {
            var sql = @"
            DELETE FROM OrcamentoItem
            WHERE CdEmpresa = ?
                AND CdFilial = ?
                AND NumOrcamento = ?
                AND Seq = ?
            ";

            return _dataAccess.Connection.Execute(sql,
                new
                {
                    CdEmpresa = entity.CdEmpresa,
                    CdFilial = entity.CdFilial,
                    NumOrcamento = entity.NumOrcamento,
                    Seq = entity.Seq
                },
                transaction: _dataAccess.Transaction) > 0;
        }
        public OrcamentoItem ObterItem(string cdEmpresa, string cdFilial, int numOrcamento, int seq)
        {
            var sql = @"
            SELECT Seq, CdEmpresa, CdFilial, NumOrcamento, qtdproduto, stitem, tpregistro as TpProduto, cdproduto, vlvenda as PrecoTabela, vlcalculado as PrecoVenda, percaltpreco as PercAltPreco
                FROM  
            OrcamentoItem
                WHERE CdEmpresa = ? AND CdFilial = ? AND NumOrcamento = ? AND Seq = ?
            ";
            var items = _dataAccess.Connection.Query<OrcamentoItem, OrcamentoProduto, OrcamentoItemPreco, OrcamentoItem>(sql,
                (item, produto, preco) => {

                    if (produto != null)
                        item.DefinirProduto(produto);

                    if (preco != null)
                        item.DefinirPreco(preco);

                    return item;
                },
                new
                {
                    CdEmpresa = cdEmpresa,
                    CdFilial = cdFilial,
                    NumOrcamento = numOrcamento,
                    Seq = seq
                },
                splitOn: "TpProduto, PrecoTabela",
                transaction: _dataAccess.Transaction);

            return items.FirstOrDefault();
        }

        public IEnumerable<OrcamentoItem> ObterItems(string cdEmpresa, string cdFilial, int numOrcamento)
        {
            var sql = @"
            SELECT Seq, CdEmpresa, CdFilial, NumOrcamento, qtdproduto, stitem, tpregistro as TpProduto, cdproduto, vlvenda as PrecoTabela, vlcalculado as PrecoVenda, percaltpreco as PercAltPreco
                FROM  
            OrcamentoItem
                WHERE CdEmpresa = ? AND CdFilial = ? AND NumOrcamento = ?
            ";
            var items = _dataAccess.Connection.Query<OrcamentoItem, OrcamentoProduto, OrcamentoItemPreco, OrcamentoItem>(sql,
                (item, produto, preco) => {

                    if (produto != null)
                        item.DefinirProduto(produto);

                    if (preco != null)
                        item.DefinirPreco(preco);

                    return item;
                },
                new
                {
                    CdEmpresa = cdEmpresa,
                    CdFilial = cdFilial,
                    NumOrcamento = numOrcamento
                },
                splitOn: "TpProduto, PrecoTabela",
                transaction: _dataAccess.Transaction);

            return items;
        }
        #endregion


    }
}
