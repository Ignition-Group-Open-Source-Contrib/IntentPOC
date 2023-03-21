using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.CreateProducts
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, Guid>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateProductsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            var newProducts = new Products
            {
                Sku = request.Sku,
                Label = request.Label,
                Status = request.Status,
                CreatedDate = request.CreatedDate,
                ModifiedDate = request.ModifiedDate,
            };

            _productsRepository.Add(newProducts);
            await _productsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newProducts.Id;
        }
    }
}