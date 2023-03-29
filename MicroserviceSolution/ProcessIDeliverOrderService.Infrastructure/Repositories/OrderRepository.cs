using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using ProcessIDeliverOrderService.Domain.Entities;
using ProcessIDeliverOrderService.Domain.Repositories;
using ProcessIDeliverOrderService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace ProcessIDeliverOrderService.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class OrderRepository : RepositoryBase<Order, Order, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> FindByIdAsync(int orderId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderId == orderId, cancellationToken);
        }

        public async Task<List<Order>> FindByIdsAsync(int[] orderIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderIds.Contains(x.OrderId), cancellationToken);
        }
    }
}