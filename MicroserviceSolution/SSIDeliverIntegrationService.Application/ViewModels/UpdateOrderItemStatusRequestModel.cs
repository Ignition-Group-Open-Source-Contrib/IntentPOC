using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class UpdateOrderItemStatusRequestModel
    {
        public UpdateOrderItemStatusRequestModel()
        {
        }

        public static UpdateOrderItemStatusRequestModel Create(
            int orderId,
            IEnumerable<int> orderItemIds,
            string statusMessage,
            int orderStatusDetailId)
        {
            return new UpdateOrderItemStatusRequestModel
            {
                OrderId = orderId,
                OrderItemIds = orderItemIds,
                StatusMessage = statusMessage,
                OrderStatusDetailId = orderStatusDetailId,
            };
        }

        public int OrderId { get; set; }

        public IEnumerable<int> OrderItemIds { get; set; }

        public string StatusMessage { get; set; }

        public int OrderStatusDetailId { get; set; }

    }
}