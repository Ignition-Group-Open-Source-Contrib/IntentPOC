using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class ResumeOrderRequestModel
    {
        public ResumeOrderRequestModel()
        {
        }

        public static ResumeOrderRequestModel Create(
            int orderItemId,
            int orderStatusDetailId,
            string remarks)
        {
            return new ResumeOrderRequestModel
            {
                OrderItemId = orderItemId,
                OrderStatusDetailId = orderStatusDetailId,
                Remarks = remarks,
            };
        }

        public int OrderItemId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public string Remarks { get; set; }

    }
}