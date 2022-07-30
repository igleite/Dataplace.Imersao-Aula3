using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Application.PipelineBehavior;
using MediatR.Extensions.AttributedBehaviors;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    [MediatRBehavior(typeof(RetryBehavior<ExcluirItemCommand, bool>))]
    public class ExcluirItemCommand : DeleteCommand<OrcamentoItemViewModel>
    {
        public ExcluirItemCommand(OrcamentoItemViewModel item) : base(item)
        {
        }
    }
}
