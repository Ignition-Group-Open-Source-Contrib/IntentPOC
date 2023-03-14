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
    public class OrderRepository : RepositoryBase<Order, Order, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> FindByIdAsync(int orderID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderID == orderID, cancellationToken);
        }

        public async Task<List<Order>> FindByIdsAsync(int[] orderIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderIDs.Contains(x.OrderID), cancellationToken);
        }
    }
}