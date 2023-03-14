using System;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.DeleteProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductCatalogueCommandHandler : IRequestHandler<DeleteProductCatalogueCommand>
    {
        private readonly IProductCatalogueRepository _productCatalogueRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteProductCatalogueCommandHandler(IProductCatalogueRepository productCatalogueRepository)
        {
            _productCatalogueRepository = productCatalogueRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteProductCatalogueCommand request, CancellationToken cancellationToken)
        {
            var existingProductCatalogue = await _productCatalogueRepository.FindByIdAsync(request.Id, cancellationToken);
            _productCatalogueRepository.Remove(existingProductCatalogue);
            return Unit.Value;
        }
    }
}