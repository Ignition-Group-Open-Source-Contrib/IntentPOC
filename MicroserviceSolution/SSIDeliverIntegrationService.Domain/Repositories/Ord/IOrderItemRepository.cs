using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IOrderItemRepository : IRepository<OrderItem, OrderItem>
    {

        [IntentManaged(Mode.Fully)]
        Task<OrderItem> FindByIdAsync(int orderItemId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<OrderItem>> FindByIdsAsync(int[] orderItemIds, CancellationToken cancellationToken = default);
    }
}