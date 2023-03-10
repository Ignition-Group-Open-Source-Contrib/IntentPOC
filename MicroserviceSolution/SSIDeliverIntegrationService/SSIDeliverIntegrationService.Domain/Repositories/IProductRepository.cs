using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IProductRepository : IRepository<Product, Product>
    {

        [IntentManaged(Mode.Fully)]
        Task<Product> FindByIdAsync(int productId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Product>> FindByIdsAsync(int[] productIds, CancellationToken cancellationToken = default);
    }
}