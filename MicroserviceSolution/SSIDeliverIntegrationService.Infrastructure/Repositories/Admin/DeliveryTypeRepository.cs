using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Admin;
using SSIDeliverIntegrationService.Domain.Repositories.Admin;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Admin
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeliveryTypeRepository : RepositoryBase<DeliveryType, DeliveryType, ApplicationDbContext>, IDeliveryTypeRepository
    {
        public DeliveryTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<DeliveryType> FindByIdAsync(int deliveryTypeId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.DeliveryTypeId == deliveryTypeId, cancellationToken);
        }

        public async Task<List<DeliveryType>> FindByIdsAsync(int[] deliveryTypeIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => deliveryTypeIds.Contains(x.DeliveryTypeId), cancellationToken);
        }
    }
}