using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Stock
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IIDeliverProductChannelMappingRepository : IRepository<IDeliverProductChannelMapping, IDeliverProductChannelMapping>
    {

        [IntentManaged(Mode.Fully)]
        Task<IDeliverProductChannelMapping> FindByIdAsync(int iDeliverProductChannelMappingId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<IDeliverProductChannelMapping>> FindByIdsAsync(int[] iDeliverProductChannelMappingIds, CancellationToken cancellationToken = default);

        Task<int> FindChannelIdByProductId(int productId, CancellationToken cancellationToken = default);
    }
}