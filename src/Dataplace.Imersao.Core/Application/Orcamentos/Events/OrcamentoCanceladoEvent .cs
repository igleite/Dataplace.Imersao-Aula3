using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoCanceladoEvent : OrcamentoEventBase
    {
        public OrcamentoCanceladoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
