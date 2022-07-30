using System.Collections.Generic;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.Repositories
{
    public  interface IOrcamentoRepository
    {
        int? AdicionarOrcamento(Orcamento entity);
        bool AtualizarOrcamento(Orcamento entity);
        bool ExcluirOrcamento(Orcamento entity);
        Orcamento ObterOrcamento(string cdEmpresa, string cdFilail, int numOrcamento);
        Orcamento ObterOrcamentoComItems(string cdEmpresa, string cdFilail, int numOrcamento);
 
        int? AdicionarItem(OrcamentoItem entity);
        bool AtualizarItem(OrcamentoItem entity);
        bool ExcluirItem(OrcamentoItem entity);
        OrcamentoItem ObterItem(string cdEmpresa, string cdFilail, int numOrcamento, int seq);
        IEnumerable<OrcamentoItem> ObterItems(string cdEmpresa, string cdFilial, int numOrcamento);
    }

    
}
