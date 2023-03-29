using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application
{

    public class UpdateOrderStatusRequestModel
    {
        public UpdateOrderStatusRequestModel()
        {
        }

        public static UpdateOrderStatusRequestModel Create(
            int status)
        {
            return new UpdateOrderStatusRequestModel
            {
                Status = status,
            };
        }

        public int Status { get; set; }

    }
}