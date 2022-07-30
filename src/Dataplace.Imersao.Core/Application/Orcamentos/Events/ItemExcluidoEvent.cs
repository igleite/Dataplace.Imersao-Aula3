using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class ItemExcluidoEvent : ItemEventBase
    {
        public ItemExcluidoEvent(OrcamentoItemViewModel item) : base(item)
        {
        }
    }
}
