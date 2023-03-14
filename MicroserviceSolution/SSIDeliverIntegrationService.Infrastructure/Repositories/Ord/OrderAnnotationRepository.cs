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
    public class OrderAnnotationRepository : RepositoryBase<OrderAnnotation, OrderAnnotation, ApplicationDbContext>, IOrderAnnotationRepository
    {
        public OrderAnnotationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<OrderAnnotation> FindByIdAsync(int orderAnnotationId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.OrderAnnotationId == orderAnnotationId, cancellationToken);
        }

        public async Task<List<OrderAnnotation>> FindByIdsAsync(int[] orderAnnotationIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => orderAnnotationIds.Contains(x.OrderAnnotationId), cancellationToken);
        }
    }
}