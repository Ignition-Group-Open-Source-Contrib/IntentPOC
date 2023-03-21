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

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProductsAttributes
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductsAttributesCommandHandler : IRequestHandler<UpdateProductsAttributesCommand>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateProductsAttributesCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateProductsAttributesCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }
            var element = aggregateRoot.Attributes.FirstOrDefault(p => p.Id == request.Id);
            if (element == null)
            {
                throw new InvalidOperationException($"{nameof(Attributes)} of Id '{request.Id}' could not be found associated with {nameof(Products)} of Id '{request.ProductsId}'");
            }
#warning No matching field found for ProductsId
            element.Name = request.Name;
            element.Type = request.Type;
            element.Value = request.Value;
            _productsRepository.Update(p => p.Id == request.Id, existingAttributes);
            return Unit.Value;
        }
    }
}