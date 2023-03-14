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
    public class CustomerRepository : RepositoryBase<Customer, Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> FindByIdAsync(int customerID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CustomerID == customerID, cancellationToken);
        }

        public async Task<List<Customer>> FindByIdsAsync(int[] customerIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => customerIDs.Contains(x.CustomerID), cancellationToken);
        }
    }
}