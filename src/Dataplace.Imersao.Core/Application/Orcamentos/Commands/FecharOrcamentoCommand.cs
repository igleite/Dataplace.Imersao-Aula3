using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Application.PipelineBehavior;
using MediatR.Extensions.AttributedBehaviors;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    [MediatRBehavior(typeof(InfiniteBehavior<FecharOrcamentoCommand, bool>))]
    public class FecharOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public FecharOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
