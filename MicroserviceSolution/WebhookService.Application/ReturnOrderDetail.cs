using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace WebhookService.Application
{

    public class ReturnOrderDetail
    {
        public ReturnOrderDetail()
        {
        }

        public static ReturnOrderDetail Create(
            string orderRef,
            string serialNumber,
            string returnState,
            string itemStatus,
            int orderItemId)
        {
            return new ReturnOrderDetail
            {
                OrderRef = orderRef,
                SerialNumber = serialNumber,
                ReturnState = returnState,
                ItemStatus = itemStatus,
                OrderItemId = orderItemId,
            };
        }

        public string OrderRef { get; set; }

        public string SerialNumber { get; set; }

        public string ReturnState { get; set; }

        public string ItemStatus { get; set; }

        public int OrderItemId { get; set; }

    }
}