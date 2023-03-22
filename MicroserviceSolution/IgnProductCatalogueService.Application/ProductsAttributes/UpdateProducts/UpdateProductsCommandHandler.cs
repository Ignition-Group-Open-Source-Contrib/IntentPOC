using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Common;
using IgnProductCatalogueService.Domain.Entities;
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
            existingProducts.Attributes.UpdateCollection(request.Attributes, (e, d) => e.Id == d.Id, UpdateAttributes);
            existingProducts.Relationships.UpdateCollection(request.Relationships, (e, d) => e.Id == d.Id, UpdateRelationships);
            _productsRepository.Update(p => p.Id == request.Id, existingProducts);
            return Unit.Value;
        }

        [IntentManaged(Mode.Fully)]
        private static void UpdateAttributes(Attributes entity, UpdateProductsAttributesDto dto)
        {
            entity.Name = dto.Name;
            entity.Label = dto.Label;
            entity.Description = dto.Description;
            entity.Type = dto.Type;
            entity.Value = dto.Value;
            entity.Options = dto.Options;
        }

        [IntentManaged(Mode.Fully)]
        private static void UpdateRelationships(Relationships entity, UpdateProductsRelationshipsDto dto)
        {
            entity.ProductId = dto.ProductId;
        }
    }
}