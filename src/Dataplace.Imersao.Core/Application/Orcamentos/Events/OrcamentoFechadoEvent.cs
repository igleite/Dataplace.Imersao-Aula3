using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class OrcamentoFechadoEvent : OrcamentoEventBase
    {
        public OrcamentoFechadoEvent(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
