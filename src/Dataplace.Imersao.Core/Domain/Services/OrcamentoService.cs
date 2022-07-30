using Dataplace.Imersao.Core.Domain.Orcamentos;
using Dataplace.Imersao.Core.Domain.Orcamentos.Repositories;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using Dataplace.Imersao.Core.Domain.Produtos;
using Dataplace.Imersao.Core.Domain.Produtos.Repositories;

namespace Dataplace.Imersao.Core.Domain.Services
{
    public interface IOrcamentoService
    {
        OrcamentoItemPreco ObterProdutoPreco(Orcamento orcamento , OrcamentoProduto  produto);
    }
    public class OrcamentoService : IOrcamentoService
    {
        #region field
        private readonly IOrcamentoRepository _orcamentoRepository;
        private readonly IProdutoRepository _produtoRepository;
        #endregion

        #region constructors
        public OrcamentoService(
                IOrcamentoRepository orcamentoRepository, 
                IProdutoRepository produtoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
            _produtoRepository = produtoRepository;
        }
        #endregion

        #region methods

        public OrcamentoItemPreco ObterProdutoPreco(Orcamento orcamento, OrcamentoProduto produto)
        {
            if (orcamento.TabelaPreco == null || !orcamento.TabelaPreco.IsValid() || !produto.IsValid())
                return default;

            var produtoPreco =  _produtoRepository.ObterProdutoPreco(produto.TpProduto, produto.CdProduto, orcamento.TabelaPreco.CdTabela, orcamento.TabelaPreco.SqTabela, orcamento.CdEmpresa, orcamento.CdFilial);

            return new OrcamentoItemPrecoPercentual(produtoPreco?.ValorVenda ?? decimal.Zero, 0);

        }
        #endregion
    }
}
