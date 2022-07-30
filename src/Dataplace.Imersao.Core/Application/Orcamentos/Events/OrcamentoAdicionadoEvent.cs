using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoAdicionadoEvent : OrcamentoEventBase
    {
        public OrcamentoAdicionadoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
