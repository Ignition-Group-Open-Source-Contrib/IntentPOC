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

namespace IgnProductCatalogueService.Application.ProductCatalogues.CreateProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductCatalogueCommandHandler : IRequestHandler<CreateProductCatalogueCommand, string>
    {
        private readonly IProductCatalogueRepository _productCatalogueRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateProductCatalogueCommandHandler(IProductCatalogueRepository productCatalogueRepository)
        {
            _productCatalogueRepository = productCatalogueRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<string> Handle(CreateProductCatalogueCommand request, CancellationToken cancellationToken)
        {
            var newProductCatalogue = new ProductCatalogue
            {
                Sku = request.Sku,
                Label = request.Label,
                Status = request.Status,
                ParentId = request.ParentId,
                Attributes = request.Attributes,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            _productCatalogueRepository.Add(newProductCatalogue);
            await _productCatalogueRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newProductCatalogue.Id;
        }
    }
}