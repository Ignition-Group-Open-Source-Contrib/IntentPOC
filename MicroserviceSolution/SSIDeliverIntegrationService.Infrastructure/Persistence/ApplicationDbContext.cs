using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Entities;
using SSIDeliverIntegrationService.Domain.Entities.Admin;
using SSIDeliverIntegrationService.Domain.Entities.Camp;
using SSIDeliverIntegrationService.Domain.Entities.Cust;
using SSIDeliverIntegrationService.Domain.Entities.Deals;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using SSIDeliverIntegrationService.Domain.Entities.Stock;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Admin;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Camp;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Cust;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Deals;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord;
using SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.DbContext", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<BulkIDeliverOrderFileUpload> BulkIDeliverOrderFileUploads { get; set; }
        public DbSet<CampaignIDeliverCourierMapping> CampaignIDeliverCourierMappings { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealProductMapping> DealProductMappings { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<IDeliverCampaignChannelMapping> IDeliverCampaignChannelMappings { get; set; }
        public DbSet<IDeliverOrderInfo> IDeliverOrderInfos { get; set; }
        public DbSet<IDeliverProductChannelMapping> IDeliverProductChannelMappings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAnnotation> OrderAnnotations { get; set; }
        public DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDimensions> ProductDimensions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<VASXProviderSpecific> VASXProviderSpecifics { get; set; }
        public DbSet<VwGetCustomerAddress> VwGetCustomerAddresses { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await DispatchEvents();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureModel(modelBuilder);
            modelBuilder.ApplyConfiguration(new BulkIDeliverOrderFileUploadConfiguration());
            modelBuilder.ApplyConfiguration(new CampaignIDeliverCourierMappingConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerContactConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new DealProductMappingConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IDeliverCampaignChannelMappingConfiguration());
            modelBuilder.ApplyConfiguration(new IDeliverOrderInfoConfiguration());
            modelBuilder.ApplyConfiguration(new IDeliverProductChannelMappingConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAnnotationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDeliveryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDimensionsConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new StockItemConfiguration());
            modelBuilder.ApplyConfiguration(new TariffConfiguration());
            modelBuilder.ApplyConfiguration(new VASXProviderSpecificConfiguration());
            modelBuilder.ApplyConfiguration(new VwGetCustomerAddressConfiguration());
        }

        [IntentManaged(Mode.Ignore)]
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
            // Seed data
            // https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
            /* Eg.
            
            modelBuilder.Entity<Car>().HasData(
            new Car() { CarId = 1, Make = "Ferrari", Model = "F40" },
            new Car() { CarId = 2, Make = "Ferrari", Model = "F50" },
            new Car() { CarId = 3, Make = "Labourghini", Model = "Countach" });
            */
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }
    }
}