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
    public class OrderDeliveryRepository : RepositoryBase<OrderDelivery, OrderDelivery, ApplicationDbContext>, IOrderDeliveryRepository
    {
        public OrderDeliveryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<OrderDelivery> FindByIdAsync(int orderDeliveryId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderDeliveryId == orderDeliveryId, cancellationToken);
        }

        public async Task<List<OrderDelivery>> FindByIdsAsync(int[] orderDeliveryIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderDeliveryIds.Contains(x.OrderDeliveryId), cancellationToken);
        }
    }
}