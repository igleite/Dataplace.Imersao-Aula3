using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;

namespace Dataplace.Imersao.Core.Domain.Produtos.Repositories
{
    public interface IProdutoRepository
    {
        ProdutoPreco ObterProdutoPreco(TpRegistroEnum tpRegistro, string cdProduto, string cdTabela, short sqTabela, string cdEmpresa, string cdFilial);
    }
}
