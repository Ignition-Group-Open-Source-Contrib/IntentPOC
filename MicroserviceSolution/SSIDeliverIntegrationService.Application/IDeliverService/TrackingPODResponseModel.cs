using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class TrackingPODResponseModel
    {
        public static TrackingPODResponseModel Create(
            string type,
            string base64_encoded)
        {
            return new TrackingPODResponseModel
            {
                Type = type,
                Base64_encoded = base64_encoded,
            };
        }

        public string Type { get; set; }

        public string Base64_encoded { get; set; }
    }
}