using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Application.Common.Interfaces;
using SSIDeliverIntgnService.Domain.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.Behaviours.MongoDbUnitOfWorkBehaviour", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Common.Behaviours
{
    public class MongoDbUnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICommand
    {
        private readonly IMongoDbUnitOfWork _dataSource;

        public MongoDbUnitOfWorkBehaviour(IMongoDbUnitOfWork dataSource)
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