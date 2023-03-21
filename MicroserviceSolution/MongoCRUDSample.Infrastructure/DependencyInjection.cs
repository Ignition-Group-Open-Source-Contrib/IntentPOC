using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoCRUDSample.Application.Common.Interfaces;
using MongoCRUDSample.Domain.Common.Interfaces;
using MongoCRUDSample.Domain.Repositories;
using MongoCRUDSample.Infrastructure.Persistence;
using MongoCRUDSample.Infrastructure.Repositories;
using MongoCRUDSample.Infrastructure.Services;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace MongoCRUDSample.Infrastructure
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
            services.AddTransient<IProductEntityRepository, ProductEntityRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddMongoDbUnitOfWork();
            services.AddMongoDbUnitOfWork<ApplicationMongoDbContext>();
            return services;
        }
    }
}