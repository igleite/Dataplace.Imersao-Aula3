using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class AtualizarItemCommand : UpdateCommand<OrcamentoItemViewModel>
    {
        public AtualizarItemCommand(OrcamentoItemViewModel item) : base(item)
        {

        }
    }
}
