using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.DeleteProductEntity
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductEntityCommandHandler : IRequestHandler<DeleteProductEntityCommand>
    {
        private readonly IProductEntityRepository _productEntityRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteProductEntityCommandHandler(IProductEntityRepository productEntityRepository)
        {
            _productEntityRepository = productEntityRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteProductEntityCommand request, CancellationToken cancellationToken)
        {
            var existingProductEntity = await _productEntityRepository.FindByIdAsync(request.Id, cancellationToken);
            _productEntityRepository.Remove(existingProductEntity);
            return Unit.Value;
        }
    }
}