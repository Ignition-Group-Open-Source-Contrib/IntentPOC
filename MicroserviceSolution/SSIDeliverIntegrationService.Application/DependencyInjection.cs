using System.Reflection;
using AutoMapper;
using FluentValidation;
using IgnitionGroup.AzureStorageQueueHelper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSIDeliverIntegrationService.Application.Common.Behaviours;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Application.Common.Configuration;
using SSIDeliverIntegrationService.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.Application.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EventBusPublishBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StateRepositoryUnitOfWorkBehaviour<,>));
            services.AddScoped<IEventBus, EventBusImplementation>();
            services.AddScoped<ISSIDeliverIntegrationFacade, SSIDeliverIntegrationFacade>();
            services.AddSingleton<IWorkflowStorageFactory, WorkflowStorageFactory>();
            services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
            return services;
        }
    }
}