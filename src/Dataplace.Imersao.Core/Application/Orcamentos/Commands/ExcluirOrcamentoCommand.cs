
using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using MediatR.Extensions.AttributedBehaviors;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    [MediatRBehavior(typeof(Dataplace.Core.Comunications.Behaviors.DeadlockRetryBehavior<ExcluirOrcamentoCommand, bool>))]
    public class ExcluirOrcamentoCommand : DeleteCommand<OrcamentoViewModel>
    {
        public ExcluirOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
