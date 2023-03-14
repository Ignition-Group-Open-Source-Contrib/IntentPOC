using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Stock;
using SSIDeliverIntegrationService.Domain.Repositories.Stock;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Stock
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ProductDimensionsRepository : RepositoryBase<ProductDimensions, ProductDimensions, ApplicationDbContext>, IProductDimensionsRepository
    {
        public ProductDimensionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProductDimensions> FindByIdAsync(int productDimensionsId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ProductDimensionsId == productDimensionsId, cancellationToken);
        }

        public async Task<List<ProductDimensions>> FindByIdsAsync(int[] productDimensionsIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => productDimensionsIds.Contains(x.ProductDimensionsId), cancellationToken);
        }
    }
}