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
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class OrderItemRepository : RepositoryBase<OrderItem, OrderItem, ApplicationDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<OrderItem> FindByIdAsync(int orderItemId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderItemId == orderItemId, cancellationToken);
        }

        public async Task<List<OrderItem>> FindByIdsAsync(int[] orderItemIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderItemIds.Contains(x.OrderItemId), cancellationToken);
        }


    }
}