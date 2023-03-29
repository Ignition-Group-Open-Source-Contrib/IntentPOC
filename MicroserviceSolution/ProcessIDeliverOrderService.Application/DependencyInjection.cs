using System.Reflection;
using AutoMapper;
using FluentValidation;
using IgnitionGroup.AzureStorageQueueHelper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProcessIDeliverOrderService.Application.BackgroundWorker;
using ProcessIDeliverOrderService.Application.Common.Behaviours;
using ProcessIDeliverOrderService.Application.Common.BusinessLogic;
using ProcessIDeliverOrderService.Application.Common.Configuration;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.Application.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace ProcessIDeliverOrderService.Application
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StateRepositoryUnitOfWorkBehaviour<,>));
            services.AddSingleton<IWorkflowStorageFactory, WorkflowStorageFactory>();
            services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
            services.AddScoped<ISSIDeliverIntegrationFacade, SSIDeliverIntegrationFacade>();
            services.AddHostedService<ProcessIDeliverOrder>();
            return services;
        }
    }
}