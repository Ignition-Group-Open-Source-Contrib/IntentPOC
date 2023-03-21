using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MongoCRUDSample.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace MongoCRUDSample.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IProductEntityRepository : IRepository<ProductEntity, ProductEntity>
    {

        [IntentManaged(Mode.Fully)]
        object Update(Expression<Func<ProductEntity, bool>> predicate, ProductEntity entity);
        [IntentManaged(Mode.Fully)]
        Task<ProductEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<ProductEntity>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default);
    }
}