using IgnProductCatalogueService.Application.Common.Interfaces;
using IgnProductCatalogueService.Domain.Common.Interfaces;
using IgnProductCatalogueService.Domain.Repositories;
using IgnProductCatalogueService.Infrastructure.Persistence;
using IgnProductCatalogueService.Infrastructure.Repositories;
using IgnProductCatalogueService.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace IgnProductCatalogueService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationMongoDbContext>(
                provider =>
                {
                    var connectionString = configuration.GetConnectionString("MongoDbConnection");
                    var url = MongoDB.Driver.MongoUrl.Create(connectionString);
                    return new ApplicationMongoDbContext(connectionString, url.DatabaseName);
                });
            services.AddTransient<IMongoDbUnitOfWork>(provider => provider.GetService<ApplicationMongoDbContext>());
            services.AddTransient<IMongoDbContext>(provider => provider.GetService<ApplicationMongoDbContext>());
            services.AddTransient<IProductCatalogueRepository, ProductCatalogueRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddMongoDbUnitOfWork();
            services.AddMongoDbUnitOfWork<ApplicationMongoDbContext>();
            return services;
        }
    }
}