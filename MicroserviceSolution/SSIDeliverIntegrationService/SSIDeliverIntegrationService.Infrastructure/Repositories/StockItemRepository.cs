using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities;
using SSIDeliverIntegrationService.Domain.Repositories;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class StockItemRepository : RepositoryBase<StockItem, StockItem, ApplicationDbContext>, IStockItemRepository
    {
        public StockItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<StockItem> FindByIdAsync(int stockItemId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.StockItemId == stockItemId, cancellationToken);
        }

        public async Task<List<StockItem>> FindByIdsAsync(int[] stockItemIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => stockItemIds.Contains(x.StockItemId), cancellationToken);
        }
    }
}