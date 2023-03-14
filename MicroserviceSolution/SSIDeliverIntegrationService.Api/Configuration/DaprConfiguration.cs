using Dapr.Client;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;
using SSIDeliverIntegrationService.Application.IDeliverService;
using SSIDeliverIntegrationService.Infrastructure.HttpClients;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.DaprConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Api.Configuration
{
    public static class DaprConfiguration
    {
        public static void AddDaprServices(this IServiceCollection services)
        {
            services.AddSingleton<IIDeliverClient, IDeliverServiceHttpClient>(_ => new IDeliverServiceHttpClient(DaprClient.CreateInvokeHttpClient("i-deliver-service")));
        }
    }
}