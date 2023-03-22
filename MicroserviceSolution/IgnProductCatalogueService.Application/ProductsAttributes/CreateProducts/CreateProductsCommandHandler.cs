using System;
using System.Collections.Generic;
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
                Attributes = request.Attributes?.Select(CreateAttributes).ToList() ?? new List<Attributes>(),
                Relationships = request.Relationships?.Select(CreateRelationships).ToList() ?? new List<Relationships>(),
            };

            _productsRepository.Add(newProducts);
            await _productsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newProducts.Id;
        }

        [IntentManaged(Mode.Fully)]
        private static Attributes CreateAttributes(CreateProductsAttributesDto dto)
        {
            return new Attributes
            {
                Name = dto.Name,
                Type = dto.Type,
                Value = dto.Value,
                Label = dto.Label,
                Description = dto.Description,
                //Options = dto.Options,
            };
        }

        [IntentManaged(Mode.Fully)]
        private static Relationships CreateRelationships(CreateProductsRelationshipsDto dto)
        {
            return new Relationships
            {
                ProductId = dto.ProductId,
            };
        }
    }
}