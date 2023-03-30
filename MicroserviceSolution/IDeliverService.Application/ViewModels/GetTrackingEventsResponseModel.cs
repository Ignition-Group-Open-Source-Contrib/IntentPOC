using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class GetTrackingEventsResponseModel
    {
        public GetTrackingEventsResponseModel()
        {
        }

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