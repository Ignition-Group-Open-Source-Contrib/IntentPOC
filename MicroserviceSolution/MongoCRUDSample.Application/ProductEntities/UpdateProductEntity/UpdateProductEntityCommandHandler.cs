using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.UpdateProductEntity
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductEntityCommandHandler : IRequestHandler<UpdateProductEntityCommand>
    {
        private readonly IProductEntityRepository _productEntityRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateProductEntityCommandHandler(IProductEntityRepository productEntityRepository)
        {
            _productEntityRepository = productEntityRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateProductEntityCommand request, CancellationToken cancellationToken)
        {
            var existingProductEntity = await _productEntityRepository.FindByIdAsync(request.Id, cancellationToken);
            existingProductEntity.ProductName = request.ProductName;
            existingProductEntity.Sku = request.Sku;
            existingProductEntity.ProductPrice = request.ProductPrice;
            existingProductEntity.CreatedDate = request.CreatedDate;
            existingProductEntity.UpdatedDate = request.UpdatedDate;
            _productEntityRepository.Update(p => p.Id == request.Id, existingProductEntity);
            return Unit.Value;
        }
    }
}