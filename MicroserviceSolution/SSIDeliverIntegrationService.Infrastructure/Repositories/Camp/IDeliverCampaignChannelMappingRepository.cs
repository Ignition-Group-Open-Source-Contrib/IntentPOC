using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Camp;
using SSIDeliverIntegrationService.Domain.Entities.Deals;
using SSIDeliverIntegrationService.Domain.Repositories.Camp;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Camp
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class IDeliverCampaignChannelMappingRepository : RepositoryBase<IDeliverCampaignChannelMapping, IDeliverCampaignChannelMapping, ApplicationDbContext>, IIDeliverCampaignChannelMappingRepository
    {
        public IDeliverCampaignChannelMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IDeliverCampaignChannelMapping> FindByIdAsync(int iDeliverCampaignChannelMappingId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.IDeliverCampaignChannelMappingId == iDeliverCampaignChannelMappingId, cancellationToken);
        }

        public async Task<List<IDeliverCampaignChannelMapping>> FindByIdsAsync(int[] iDeliverCampaignChannelMappingIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => iDeliverCampaignChannelMappingIds.Contains(x.IDeliverCampaignChannelMappingId), cancellationToken);
        }

        public async Task<int> FindChannelIdByCampaignId(int campaignId, CancellationToken cancellationToken = default)
        {
            var iDeliverCampaignChannels = await FindAllAsync(x => x.CampaignId == campaignId, cancellationToken);
            return iDeliverCampaignChannels.Select(x => x.ChannelId).FirstOrDefault();
        }
    }
}