using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Infrastructure;
using MongoDB.UnitOfWork.Abstractions.Extensions;
using SSIDeliverIntgnService.Application.Common.Interfaces;
using SSIDeliverIntgnService.Domain.Common.Interfaces;
using SSIDeliverIntgnService.Domain.Repositories;
using SSIDeliverIntgnService.Infrastructure.Persistence;
using SSIDeliverIntgnService.Infrastructure.Repositories;
using SSIDeliverIntgnService.Infrastructure.Services;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace SSIDeliverIntgnService.Infrastructure
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
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddMongoDbUnitOfWork();
            services.AddMongoDbUnitOfWork<ApplicationMongoDbContext>();
            return services;
        }
    }
}