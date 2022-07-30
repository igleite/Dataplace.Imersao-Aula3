using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoExcluidoEvent : OrcamentoEventBase
    {
        public OrcamentoExcluidoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
