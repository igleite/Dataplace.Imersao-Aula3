using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class AtualizarOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public AtualizarOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
