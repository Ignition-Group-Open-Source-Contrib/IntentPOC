using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities;
using SSIDeliverIntegrationService.Domain.Repositories;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CustomerRepository : RepositoryBase<Customer, Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> FindByIdAsync(int customerId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CustomerId == customerId, cancellationToken);
        }

        public async Task<List<Customer>> FindByIdsAsync(int[] customerIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => customerIds.Contains(x.CustomerId), cancellationToken);
        }
    }
}