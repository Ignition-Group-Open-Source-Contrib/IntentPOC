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

namespace IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsAttributes
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductsAttributesCommandHandler : IRequestHandler<CreateProductsAttributesCommand, Guid>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateProductsAttributesCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateProductsAttributesCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }
            var newAttributes = new Attributes
            {
#warning No matching field found for ProductsId
                Name = request.Name,
                Type = request.Type,
                Value = request.Value,
                Label = request.Label,
                Description = request.Description,
                Options = request.Options,
            };

            aggregateRoot.Attributes.Add(newAttributes);
            await _productsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newAttributes.Id;
        }
    }
}