using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class ItemAtualizadoEvent : ItemEventBase
    {
        public ItemAtualizadoEvent(OrcamentoItemViewModel item) : base(item)
        {
        }
    }
}
