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
    public class CustomerAddressRepository : RepositoryBase<CustomerAddress, CustomerAddress, ApplicationDbContext>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CustomerAddress> FindByIdAsync(int customerAddressID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CustomerAddressID == customerAddressID, cancellationToken);
        }

        public async Task<List<CustomerAddress>> FindByIdsAsync(int[] customerAddressIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => customerAddressIDs.Contains(x.CustomerAddressID), cancellationToken);
        }
    }
}