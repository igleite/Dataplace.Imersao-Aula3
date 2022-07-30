using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoReabertoEvent : OrcamentoEventBase
    {
        public OrcamentoReabertoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
