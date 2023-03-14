using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Repositories;
using SSIDeliverIntegrationService.Domain.Repositories.Admin;
using SSIDeliverIntegrationService.Domain.Repositories.Camp;
using SSIDeliverIntegrationService.Domain.Repositories.Cust;
using SSIDeliverIntegrationService.Domain.Repositories.Deal;
using SSIDeliverIntegrationService.Domain.Repositories.Ord;
using SSIDeliverIntegrationService.Domain.Repositories.Stock;
using SSIDeliverIntegrationService.Infrastructure.Persistence;
using SSIDeliverIntegrationService.Infrastructure.Repositories;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Admin;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Camp;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Cust;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Deal;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Ord;
using SSIDeliverIntegrationService.Infrastructure.Repositories.Stock;
using SSIDeliverIntegrationService.Infrastructure.Services;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IBulkIDeliverOrderFileUploadRepository, BulkIDeliverOrderFileUploadRepository>();
            services.AddTransient<ICampaignIDeliverCourierMappingRepository, CampaignIDeliverCourierMappingRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();
            services.AddTransient<ICustomerContactRepository, CustomerContactRepository>();
            services.AddTransient<IDealRepository, DealRepository>();
            services.AddTransient<IDealProductMappingRepository, DealProductMappingRepository>();
            services.AddTransient<IDeliveryTypeRepository, DeliveryTypeRepository>();
            services.AddTransient<IIDeliverCampaignChannelMappingRepository, IDeliverCampaignChannelMappingRepository>();
            services.AddTransient<IIDeliverOrderInfoRepository, IDeliverOrderInfoRepository>();
            services.AddTransient<IIDeliverProductChannelMappingRepository, IDeliverProductChannelMappingRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderAnnotationRepository, OrderAnnotationRepository>();
            services.AddTransient<IOrderDeliveryRepository, OrderDeliveryRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductDimensionsRepository, ProductDimensionsRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IStockItemRepository, StockItemRepository>();
            services.AddTransient<ITariffRepository, TariffRepository>();
            services.AddTransient<IVASXProviderSpecificRepository, VASXProviderSpecificRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            return services;
        }
    }
}