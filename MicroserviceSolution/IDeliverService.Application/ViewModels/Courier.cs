using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class Courier
    {
        public Courier()
        {
        }

        public static Courier Create(
            string name,
            string tracking_url,
            string tracking_number)
        {
            return new Courier
            {
                Name = name,
                Tracking_url = tracking_url,
                Tracking_number = tracking_number,
            };
        }

        public string Name { get; set; }

        public string Tracking_url { get; set; }

        public string Tracking_number { get; set; }

    }
}