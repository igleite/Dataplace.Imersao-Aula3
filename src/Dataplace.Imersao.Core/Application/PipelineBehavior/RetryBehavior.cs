using System.Threading;
using System.Threading.Tasks;
using Dataplace.Imersao.Core.Infra.Data.Polices;
using MediatR;

namespace Dataplace.Imersao.Core.Application.PipelineBehavior
{
    public class RetryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await RetryPolicy.Instance.Execute(async () =>
            {
                return await next();
            });
        }
    }


    public class InfiniteBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await InfinityPolicy.Instance.Execute(async () =>
            {
                return await next();
            });
        }
    }
}
