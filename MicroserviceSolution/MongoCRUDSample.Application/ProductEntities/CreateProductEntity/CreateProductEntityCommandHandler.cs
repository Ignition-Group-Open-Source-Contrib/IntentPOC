using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Domain.Entities;
using MongoCRUDSample.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.CreateProductEntity
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductEntityCommandHandler : IRequestHandler<CreateProductEntityCommand, string>
    {
        private readonly IProductEntityRepository _productEntityRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateProductEntityCommandHandler(IProductEntityRepository productEntityRepository)
        {
            _productEntityRepository = productEntityRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<string> Handle(CreateProductEntityCommand request, CancellationToken cancellationToken)
        {
            var newProductEntity = new ProductEntity
            {
                ProductName = request.ProductName,
                Sku = request.Sku,
                ProductPrice = request.ProductPrice,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate,
            };

            _productEntityRepository.Add(newProductEntity);
            await _productEntityRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newProductEntity.Id;
        }
    }
}