using Intent.RoslynWeaver.Attributes;
using MarketicOrderService.Application.Common.Interfaces;
using MarketicOrderService.Domain.Common.Interfaces;
using MarketicOrderService.Domain.Repositories;
using MarketicOrderService.Infrastructure.Persistence;
using MarketicOrderService.Infrastructure.Repositories;
using MarketicOrderService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace MarketicOrderService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("DefaultConnection");
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<ApplicationMongoDbContext>(
                provider =>
                {
                    var connectionString = configuration.GetConnectionString("MongoDbConnection");
                    var url = MongoDB.Driver.MongoUrl.Create(connectionString);
                    return new ApplicationMongoDbContext(connectionString, url.DatabaseName);
                });
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IMongoDbUnitOfWork>(provider => provider.GetService<ApplicationMongoDbContext>());
            services.AddTransient<IMongoDbContext>(provider => provider.GetService<ApplicationMongoDbContext>());
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddMongoDbUnitOfWork();
            services.AddMongoDbUnitOfWork<ApplicationMongoDbContext>();
            return services;
        }
    }
}