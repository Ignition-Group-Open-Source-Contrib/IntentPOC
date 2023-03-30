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
    public class VwGetCustomerAddressRepository : RepositoryBase<VwGetCustomerAddress, VwGetCustomerAddress, ApplicationDbContext>, IVwGetCustomerAddressRepository
    {
        public VwGetCustomerAddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VwGetCustomerAddress> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CustomerAddressId == id, cancellationToken);
        }

        public async Task<List<VwGetCustomerAddress>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.CustomerAddressId), cancellationToken);
        }

        public async Task<List<VwGetCustomerAddress>> FindByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => x.CustomerId == customerId, cancellationToken);
        }
    }
}