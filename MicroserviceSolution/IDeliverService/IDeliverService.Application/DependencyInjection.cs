using System.Reflection;
using AutoMapper;
using FluentValidation;
using IDeliverService.Application.Common.Behaviours;
using IDeliverService.Application.Common.Eventing;
using IDeliverService.Application.ThirdPartyServices;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.Application.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace IDeliverService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EventBusPublishBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StateRepositoryUnitOfWorkBehaviour<,>));
            services.AddScoped<IEventBus, EventBusImplementation>();           
           // services.AddTransient<IIDeliverApi, IDeliverApi>();
            return services;
        }
    }
}