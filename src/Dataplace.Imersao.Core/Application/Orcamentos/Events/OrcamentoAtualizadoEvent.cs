using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoAtualizadoEvent : OrcamentoEventBase
    {
        public OrcamentoAtualizadoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
