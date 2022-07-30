using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class ItemAdicionadoEvent : ItemEventBase
    {
        public ItemAdicionadoEvent(OrcamentoItemViewModel item) : base(item)
        {
        }
    }
}
