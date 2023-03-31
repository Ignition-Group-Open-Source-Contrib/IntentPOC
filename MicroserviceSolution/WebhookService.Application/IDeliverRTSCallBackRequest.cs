using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace WebhookService.Application
{

    public class IDeliverRTSCallBackRequest
    {
        public IDeliverRTSCallBackRequest()
        {
        }

        public static IDeliverRTSCallBackRequest Create(
            int iDeliverOrderId,
            List<ReturnOrderDetail> orderDetails)
        {
            return new IDeliverRTSCallBackRequest
            {
                IDeliverOrderId = iDeliverOrderId,
                OrderDetails = orderDetails,
            };
        }

        public int IDeliverOrderId { get; set; }

        public List<ReturnOrderDetail> OrderDetails { get; set; }

    }
}