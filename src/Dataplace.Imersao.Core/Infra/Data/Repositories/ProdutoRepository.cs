using Dapper;
using Dataplace.Core.Infra.Data.OdbcConnection;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Core.Domain.Produtos;
using Dataplace.Imersao.Core.Domain.Produtos.Repositories;
using dpLibrary05;

namespace Dataplace.Imersao.Core.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        
        #region fields
        private readonly IDataAccess _dataAccess = null;
        #endregion
        #region constructors

        public ProdutoRepository(IOdbcDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        #endregion

        public ProdutoPreco ObterProdutoPreco(TpRegistroEnum tpRegistro, string cdProduto, string cdTabela, short sqTabela, string cdEmpresa, string cdFilial)
        {
            var sql = @"
            SELECT 
                 produtopreco.VlVenda as ValorVenda
                ,produtopreco.cdindicevenda as CdIndice
            FROM
                produtopreco
            WHERE cdProduto = ?
                AND tpitem = ?
                AND CdTabela = ?
                AND SqTabela = ?
                AND cdempresa = ?
                AND cdfilial = ?
            ";

            return _dataAccess.Connection.QueryFirstOrDefault<ProdutoPreco>(sql,
                new
                {
                    cdProduto = cdProduto,
                    tpRegistro = tpRegistro.ToDataValue(),
                    cdTabela = cdTabela,
                    sqTabela = sqTabela,
                    cdEmpresa = cdEmpresa,
                    cdFilial = cdFilial
                },
                transaction: _dataAccess.Transaction);

        }
    }
}
