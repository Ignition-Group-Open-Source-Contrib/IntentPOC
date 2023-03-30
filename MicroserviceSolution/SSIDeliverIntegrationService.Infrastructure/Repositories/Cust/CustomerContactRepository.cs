using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Cust;
using SSIDeliverIntegrationService.Domain.Repositories.Cust;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Cust
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CustomerContactRepository : RepositoryBase<CustomerContact, CustomerContact, ApplicationDbContext>, ICustomerContactRepository
    {
        public CustomerContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CustomerContact> FindByIdAsync(int customerContactId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CustomerContactId == customerContactId, cancellationToken);
        }

        public async Task<List<CustomerContact>> FindByIdsAsync(int[] customerContactIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => customerContactIds.Contains(x.CustomerContactId), cancellationToken);
        }

        public async Task<List<CustomerContact>> FindByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => x.CustomerID == customerId, cancellationToken);
        }
    }
}