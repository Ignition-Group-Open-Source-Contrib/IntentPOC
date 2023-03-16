using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.UpdateProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductCatalogueCommandHandler : IRequestHandler<UpdateProductCatalogueCommand>
    {
        private readonly IProductCatalogueRepository _productCatalogueRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateProductCatalogueCommandHandler(IProductCatalogueRepository productCatalogueRepository)
        {
            _productCatalogueRepository = productCatalogueRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(UpdateProductCatalogueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProductCatalogue = await _productCatalogueRepository.FindByIdAsync(request.Id, cancellationToken);
                existingProductCatalogue.Sku = request.Sku;
                existingProductCatalogue.Label = request.Label;
                existingProductCatalogue.Status = request.Status;
                existingProductCatalogue.ParentId = request.ParentId;
                existingProductCatalogue.Attributes = request.Attributes;
                existingProductCatalogue.ModifiedDate = DateTime.Now;
                existingProductCatalogue.Relationships = request.Relationships;
                _productCatalogueRepository.Update(p => p.Id == request.Id, existingProductCatalogue);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}