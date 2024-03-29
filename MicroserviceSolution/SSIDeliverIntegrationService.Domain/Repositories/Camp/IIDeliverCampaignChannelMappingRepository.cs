using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Camp;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Camp
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IIDeliverCampaignChannelMappingRepository : IRepository<IDeliverCampaignChannelMapping, IDeliverCampaignChannelMapping>
    {

        [IntentManaged(Mode.Fully)]
        Task<IDeliverCampaignChannelMapping> FindByIdAsync(int iDeliverCampaignChannelMappingId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<IDeliverCampaignChannelMapping>> FindByIdsAsync(int[] iDeliverCampaignChannelMappingIds, CancellationToken cancellationToken = default);

        Task<int> FindChannelIdByCampaignId(int campaignId, CancellationToken cancellationToken = default);
    }
}