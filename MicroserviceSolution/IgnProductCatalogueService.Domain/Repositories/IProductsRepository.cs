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
    public interface IProductsRepository : IRepository<Products, Products>
    {

        [IntentManaged(Mode.Fully)]
        object Update(Expression<Func<Products, bool>> predicate, Products entity);
        [IntentManaged(Mode.Fully)]
        Task<Products> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Products>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}