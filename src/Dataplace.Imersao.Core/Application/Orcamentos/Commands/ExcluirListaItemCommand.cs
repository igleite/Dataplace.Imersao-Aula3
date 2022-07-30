using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using System.Collections.Generic;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class ExcluirListItemCommand : DeleteListCommand<OrcamentoItemViewModel>
    {
        public ExcluirListItemCommand(IEnumerable<OrcamentoItemViewModel> items) : base(items)
        {
        }
    }
}
