using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Stock;
using SSIDeliverIntegrationService.Domain.Repositories.Stock;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Stock
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class IDeliverProductChannelMappingRepository : RepositoryBase<IDeliverProductChannelMapping, IDeliverProductChannelMapping, ApplicationDbContext>, IIDeliverProductChannelMappingRepository
    {
        public IDeliverProductChannelMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IDeliverProductChannelMapping> FindByIdAsync(int iDeliverProductChannelMappingId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.IDeliverProductChannelMappingId == iDeliverProductChannelMappingId, cancellationToken);
        }

        public async Task<List<IDeliverProductChannelMapping>> FindByIdsAsync(int[] iDeliverProductChannelMappingIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => iDeliverProductChannelMappingIds.Contains(x.IDeliverProductChannelMappingId), cancellationToken);
        }
    }
}