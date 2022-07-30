using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class AdicionarItemCommand : RegisterCommand<OrcamentoItemViewModel>
    {
        public AdicionarItemCommand(OrcamentoItemViewModel item) : base(item)
        {

        }
    }
}
