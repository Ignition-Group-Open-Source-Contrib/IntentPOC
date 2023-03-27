using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntgnService.Domain.Entities;
using SSIDeliverIntgnService.Domain.Repositories;
using SSIDeliverIntgnService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntgnService.Infrastructure.Repositories
{
    public class OrderRepository : MongoRepositoryBase<Order, Order>, IOrderRepository
    {
        public OrderRepository(ApplicationMongoDbContext context) : base(context)
        {
        }

        public async Task<Order> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Order>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }

        public override void Remove(Order entity)
        {
            base.DeleteOne(p => p.Id == entity.Id);
        }
    }
}