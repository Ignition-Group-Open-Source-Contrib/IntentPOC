using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Intent.RoslynWeaver.Attributes;
using MarketicOrderService.Application.Common.Interfaces;
using MarketicOrderService.Domain.Common.Interfaces;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.Integration.UnitOfWorkBehaviour", Version = "1.0")]

namespace MarketicOrderService.Application.Common.Behaviours
{
    public class MongoUnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICommand
    {
        private readonly IMongoDbUnitOfWork _dataSource;

        public MongoUnitOfWorkBehaviour(IMongoDbUnitOfWork dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            await _dataSource.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}