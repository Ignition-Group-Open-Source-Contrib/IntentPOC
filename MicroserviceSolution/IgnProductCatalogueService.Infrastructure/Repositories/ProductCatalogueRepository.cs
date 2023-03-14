using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using IgnProductCatalogueService.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.Repositories.Repository", Version = "1.0")]

namespace IgnProductCatalogueService.Infrastructure.Repositories
{
    public class ProductCatalogueRepository : MongoRepositoryBase<ProductCatalogue, ProductCatalogue>, IProductCatalogueRepository
    {
        public ProductCatalogueRepository(ApplicationMongoDbContext context) : base(context)
        {
        }

        public async Task<ProductCatalogue> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<ProductCatalogue>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }

        public override void Remove(ProductCatalogue entity)
        {
            base.DeleteOne(p => p.Id == entity.Id);
        }
    }
}