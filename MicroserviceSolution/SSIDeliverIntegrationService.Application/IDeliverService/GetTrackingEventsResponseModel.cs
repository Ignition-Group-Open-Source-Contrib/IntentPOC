using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class GetTrackingEventsResponseModel
    {
        public static GetTrackingEventsResponseModel Create(
            string date,
            string time,
            string location,
            string description)
        {
            return new GetTrackingEventsResponseModel
            {
                Date = date,
                Time = time,
                Location = location,
                Description = description,
            };
        }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}