using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Stock
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IProductDimensionsRepository : IRepository<ProductDimensions, ProductDimensions>
    {

        [IntentManaged(Mode.Fully)]
        Task<ProductDimensions> FindByIdAsync(int productDimensionsId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<ProductDimensions>> FindByIdsAsync(int[] productDimensionsIds, CancellationToken cancellationToken = default);

        Task<ProductDimensions> FindByProductIdAsync(int productId, CancellationToken cancellationToken = default);

    }
}