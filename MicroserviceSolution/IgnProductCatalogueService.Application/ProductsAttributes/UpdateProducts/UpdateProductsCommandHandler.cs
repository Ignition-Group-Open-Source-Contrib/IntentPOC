using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProducts
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateProductsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            var existingProducts = await _productsRepository.FindByIdAsync(request.Id, cancellationToken);
            existingProducts.Sku = request.Sku;
            existingProducts.Label = request.Label;
            existingProducts.Status = request.Status;
            existingProducts.CreatedDate = request.CreatedDate;
            existingProducts.ModifiedDate = request.ModifiedDate;
            _productsRepository.Update(p => p.Id == request.Id, existingProducts);
            return Unit.Value;
        }
    }
}