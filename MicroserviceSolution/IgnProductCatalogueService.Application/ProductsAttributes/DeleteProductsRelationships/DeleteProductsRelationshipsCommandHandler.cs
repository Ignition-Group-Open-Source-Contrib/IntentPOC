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

namespace IgnProductCatalogueService.Application.ProductsAttributes.DeleteProductsRelationships
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductsRelationshipsCommandHandler : IRequestHandler<DeleteProductsRelationshipsCommand>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteProductsRelationshipsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteProductsRelationshipsCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }

            var element = aggregateRoot.Relationships.FirstOrDefault(p => p.Id == request.Id);
            if (element == null)
            {
                throw new InvalidOperationException($"{nameof(Relationships)} of Id '{request.Id}' could not be found associated with {nameof(Products)} of Id '{request.ProductsId}'");
            }
            aggregateRoot.Relationships.Remove(element);
            _productsRepository.Update(p => p.Id == request.ProductsId, aggregateRoot);
            return Unit.Value;
        }
    }
}