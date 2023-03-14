using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace IgnProductCatalogueService.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IProductCatalogueRepository : IRepository<ProductCatalogue, ProductCatalogue>
    {

        [IntentManaged(Mode.Fully)]
        object Update(Expression<Func<ProductCatalogue, bool>> predicate, ProductCatalogue entity);
        [IntentManaged(Mode.Fully)]
        Task<ProductCatalogue> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<ProductCatalogue>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default);
    }
}