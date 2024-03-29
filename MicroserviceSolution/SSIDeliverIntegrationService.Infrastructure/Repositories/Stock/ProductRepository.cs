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
    public class ProductRepository : RepositoryBase<Product, Product, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> FindByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ProductId == productId, cancellationToken);
        }

        public async Task<List<Product>> FindByIdsAsync(int[] productIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => productIds.Contains(x.ProductId), cancellationToken);
        }
    }
}