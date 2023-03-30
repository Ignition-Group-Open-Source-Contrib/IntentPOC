using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class SSIDeliverOrderViewModel
    {
        public SSIDeliverOrderViewModel()
        {
        }

        public static SSIDeliverOrderViewModel Create(
            int orderId,
            IEnumerable<int> orderItemIds)
        {
            return new SSIDeliverOrderViewModel
            {
                OrderId = orderId,
                OrderItemIds = orderItemIds,
            };
        }

        public int OrderId { get; set; }

        public IEnumerable<int> OrderItemIds { get; set; }

    }
}