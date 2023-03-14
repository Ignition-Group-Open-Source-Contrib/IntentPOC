using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Camp;
using SSIDeliverIntegrationService.Domain.Repositories.Camp;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Camp
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CampaignIDeliverCourierMappingRepository : RepositoryBase<CampaignIDeliverCourierMapping, CampaignIDeliverCourierMapping, ApplicationDbContext>, ICampaignIDeliverCourierMappingRepository
    {
        public CampaignIDeliverCourierMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CampaignIDeliverCourierMapping> FindByIdAsync(int campaignIDeliverCourierMappingID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CampaignIDeliverCourierMappingID == campaignIDeliverCourierMappingID, cancellationToken);
        }

        public async Task<List<CampaignIDeliverCourierMapping>> FindByIdsAsync(int[] campaignIDeliverCourierMappingIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => campaignIDeliverCourierMappingIDs.Contains(x.CampaignIDeliverCourierMappingID), cancellationToken);
        }
    }
}