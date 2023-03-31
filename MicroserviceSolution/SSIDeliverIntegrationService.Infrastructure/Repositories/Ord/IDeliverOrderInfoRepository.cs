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
    public class IDeliverOrderInfoRepository : RepositoryBase<IDeliverOrderInfo, IDeliverOrderInfo, ApplicationDbContext>, IIDeliverOrderInfoRepository
    {
        public IDeliverOrderInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IDeliverOrderInfo> FindByIdAsync(int iDeliverOrderInfoId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.IDeliverOrderInfoId == iDeliverOrderInfoId, cancellationToken);
        }

        public async Task<List<IDeliverOrderInfo>> FindByIdsAsync(int[] iDeliverOrderInfoIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => iDeliverOrderInfoIds.Contains(x.IDeliverOrderInfoId), cancellationToken);
        }

        public async Task<IDeliverOrderInfo> FindByOrderIdAsync(int orderId, int iDeliverOrderStatusId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderId == orderId && x.IDeliverOrderStatusId == iDeliverOrderStatusId, cancellationToken);
        }
    }
}