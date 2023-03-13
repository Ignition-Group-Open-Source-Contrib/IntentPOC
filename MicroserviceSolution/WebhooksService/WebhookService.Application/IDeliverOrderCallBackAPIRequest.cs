using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace WebhookService.Application
{

    public class IDeliverOrderCallBackAPIRequest
    {
        public IDeliverOrderCallBackAPIRequest()
        {
        }

        public static IDeliverOrderCallBackAPIRequest Create(
            int iDeliverOrderId,
            string wayBillNumber,
            List<OrderDetail> orderDetails,
            string saleAgreement)
        {
            return new IDeliverOrderCallBackAPIRequest
            {
                IDeliverOrderId = iDeliverOrderId,
                WayBillNumber = wayBillNumber,
                OrderDetails = orderDetails,
                SaleAgreement = saleAgreement,
            };
        }

        public int IDeliverOrderId { get; set; }

        public string WayBillNumber { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public string SaleAgreement { get; set; }

    }
}