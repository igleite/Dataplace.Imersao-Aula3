using Dataplace.Core.Domain.Events;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoEventBase : Event
    {
        public OrcamentoEventBase(OrcamentoViewModel item)
        {
            Item = item;
        }

        public OrcamentoViewModel Item { get; }
    }
}
