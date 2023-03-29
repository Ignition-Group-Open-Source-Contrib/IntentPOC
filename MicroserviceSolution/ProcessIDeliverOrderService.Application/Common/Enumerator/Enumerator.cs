using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessIDeliverOrderService.Application.Common.Enumerator
{
    public class Enumerator
    {
        //Silver Surfer Order Status
        public enum OrderStatusDetail
        {
            DispatchReady = 108,
            DispatchWaiting = 109,
            DispatchConsign = 24,
            DispatchOrdered = 25,
            DeliveryDelivered = 29,
            DeliveryRTS = 30,
            ActivationActivated = 33,
            OutforDelivery = 28,
            Returned = 132
        }
    }
}
