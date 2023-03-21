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

namespace IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsRelationships
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductsRelationshipsCommandHandler : IRequestHandler<CreateProductsRelationshipsCommand, Guid>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateProductsRelationshipsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateProductsRelationshipsCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }
            var newRelationships = new Relationships
            {
#warning No matching field found for ProductsId
                ProductId = request.ProductId,
            };

            aggregateRoot.Relationships.Add(newRelationships);
            await _productsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newRelationships.Id;
        }
    }
}