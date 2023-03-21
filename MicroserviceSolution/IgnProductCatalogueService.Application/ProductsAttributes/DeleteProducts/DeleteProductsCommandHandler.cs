using System;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.DeleteProducts
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand>
    {
        private readonly IProductsRepository _productsRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteProductsCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var existingProducts = await _productsRepository.FindByIdAsync(request.Id, cancellationToken);
            _productsRepository.Remove(existingProducts);
            return Unit.Value;
        }
    }
}