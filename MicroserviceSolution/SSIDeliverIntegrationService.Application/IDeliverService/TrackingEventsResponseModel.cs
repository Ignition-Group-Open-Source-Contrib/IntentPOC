using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class TrackingEventsResponseModel
    {
        public static TrackingEventsResponseModel Create(
            List<GetTrackingEventsResponseModel> data)
        {
            return new TrackingEventsResponseModel
            {
                Data = data,
            };
        }

        public List<GetTrackingEventsResponseModel> Data { get; set; }
    }
}