using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MongoCRUDSample.Domain.Entities;
using MongoCRUDSample.Domain.Repositories;
using MongoCRUDSample.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.Repositories.Repository", Version = "1.0")]

namespace MongoCRUDSample.Infrastructure.Repositories
{
    public class ProductEntityRepository : MongoRepositoryBase<ProductEntity, ProductEntity>, IProductEntityRepository
    {
        public ProductEntityRepository(ApplicationMongoDbContext context) : base(context)
        {
        }

        public async Task<ProductEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<ProductEntity>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }

        public override void Remove(ProductEntity entity)
        {
            base.DeleteOne(p => p.Id == entity.Id);
        }
    }
}