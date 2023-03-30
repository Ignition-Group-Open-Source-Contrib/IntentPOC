using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class TrackingEventsResponseModel
    {
        public TrackingEventsResponseModel()
        {
        }

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