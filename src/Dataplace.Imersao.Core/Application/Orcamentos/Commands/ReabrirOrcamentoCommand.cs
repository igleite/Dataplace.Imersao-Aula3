using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Application.PipelineBehavior;
using MediatR.Extensions.AttributedBehaviors;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    [MediatRBehavior(typeof(InfiniteBehavior<ReabrirOrcamentoCommand, bool>))]
    public class ReabrirOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public ReabrirOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
