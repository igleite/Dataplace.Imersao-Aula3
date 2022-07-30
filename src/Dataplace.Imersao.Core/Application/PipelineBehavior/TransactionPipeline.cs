using System.Threading;
using System.Threading.Tasks;
using Dataplace.Core.Domain.Interfaces.UoW;
using Dataplace.Core.Domain.Query;
using Dataplace.Core.Infra.Data.SqlConnection;
using MediatR;

namespace Dataplace.Imersao.Core.Application.PipelineBehavior
{

    public class TransacionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        public TransacionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await next();
        }
    }


    public class TimeOutBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : IQuery<TResponse>
    {
        private readonly ISqlDataAccess _dataAccess;
        public TimeOutBehavior(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await next();
        }
    }
}
