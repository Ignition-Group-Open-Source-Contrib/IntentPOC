using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDeliverIntegrationService.Application.Common.Enum
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

        //Silver Surfer Contact Type
        public enum ContactType
        {
            MobileNumber = 1,
            HomeNumber = 2,
            WorkNumber = 3,
            EmailAddress = 4

        }

        //Silver Surfer Contact Type
        public enum AddressType
        {
            Postal = 1,
            Residential = 2,
            Delivery = 4
        }

        //Silver Surfer CommSentStatus Type
        public enum CommSentStatus
        {
            Pending = 1
        }

        //IDeliver Order Status Type
        public enum IDeliverOrderStatus
        {
            Ready = 1,
            Dispached = 5,
            Delivered = 6,
            DeliveryRTS = 7,
            DeliveryPOD = 8,
            DeliveryCancelled = 9
        }

        //Silver Surfer Handler Trigger Event Type
        public enum HandlerEnum
        {
            DispatchHandler = 51,
            DeliveryHandler = 5
        }

        //Comms Type
        public enum CommsType
        {
            ActionDriven = 1,
            Brand = 2,
            StatusComms = 3
        }

        //Comms Action Type
        public enum ActionTypeEnum
        {
            None = 0,
            ForgotPassword = 1,
            Topup = 2,
            JobCard = 3
        }

        //IDelvier Return State
        public enum ReturnState
        {
            Sealed = 1,
            Unsealed = 2
        }

        //IDeliver Item Status
        public enum ItemStatus
        {
            [Description("reject processed")]
            RejectProcessed = 1,
            [Description("return approval pending")]
            Returnapprovalpending = 2,
            [Description("return disposed")]
            Returndisposed = 3,
            [Description("returned")]
            Returned = 4,
            [Description("processed")]
            Processed = 5
        }

        //Courier Partner Id
        public enum Courier
        {
            Skynet = 1,
            CourierIT = 2
        }
    }
}
