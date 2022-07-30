using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    public class CancelarOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public CancelarOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
