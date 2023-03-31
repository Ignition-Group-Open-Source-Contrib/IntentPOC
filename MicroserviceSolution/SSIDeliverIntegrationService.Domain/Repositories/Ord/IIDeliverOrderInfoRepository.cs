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
    public interface IIDeliverOrderInfoRepository : IRepository<IDeliverOrderInfo, IDeliverOrderInfo>
    {

        [IntentManaged(Mode.Fully)]
        Task<IDeliverOrderInfo> FindByIdAsync(int iDeliverOrderInfoId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<IDeliverOrderInfo>> FindByIdsAsync(int[] iDeliverOrderInfoIds, CancellationToken cancellationToken = default);
        Task<IDeliverOrderInfo> FindByOrderIdAsync(int orderId, int iDeliverOrderStatusId, CancellationToken cancellationToken = default);
    }
}