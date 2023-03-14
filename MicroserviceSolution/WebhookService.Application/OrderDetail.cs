using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace WebhookService.Application
{

    public class OrderDetail
    {
        public OrderDetail()
        {
        }

        public static OrderDetail Create(
            int iDeliverProductId,
            string orderRef,
            decimal? productPrice,
            string serialNumber)
        {
            return new OrderDetail
            {
                IDeliverProductId = iDeliverProductId,
                OrderRef = orderRef,
                ProductPrice = productPrice,
                SerialNumber = serialNumber,
            };
        }

        public int IDeliverProductId { get; set; }

        public string OrderRef { get; set; }

        public decimal? ProductPrice { get; set; }

        public string SerialNumber { get; set; }

    }
}