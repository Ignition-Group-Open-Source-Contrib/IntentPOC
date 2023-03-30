using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using SSIDeliverIntegrationService.Domain.Repositories.Ord;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class OrderStatusHistoryRepository : RepositoryBase<OrderStatusHistory, OrderStatusHistory, ApplicationDbContext>, IOrderStatusHistoryRepository
    {
        public OrderStatusHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<OrderStatusHistory> FindByIdAsync(int orderStatusHistoryId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderStatusHistoryId == orderStatusHistoryId, cancellationToken);
        }

        public async Task<List<OrderStatusHistory>> FindByIdsAsync(int[] orderStatusHistoryIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderStatusHistoryIds.Contains(x.OrderStatusHistoryId), cancellationToken);
        }

        public async Task<OrderStatusHistory> FindLastStatusHistoryAsync(int orderItemId, int statusDetailId)
        {
            var orderStatusHistories = await FindAllAsync(x => x.OrderItemId == orderItemId && x.OrderStatusDetailId == statusDetailId);
            return orderStatusHistories?.OrderByDescending(x => x.Occured).FirstOrDefault();
        }
    }
}