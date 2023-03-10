using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Common.Interfaces;
using SSIDeliverIntegrationService.Domain.Repositories;
using SSIDeliverIntegrationService.Infrastructure.Persistence;
using SSIDeliverIntegrationService.Infrastructure.Repositories;
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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStockItemRepository, StockItemRepository>();
            services.AddTransient<ITariffRepository, TariffRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            return services;
        }
    }
}