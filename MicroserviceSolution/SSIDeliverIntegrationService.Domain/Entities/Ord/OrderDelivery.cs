using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Admin;
using SSIDeliverIntegrationService.Domain.Entities.Cust;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderDelivery : IHasDomainEvent
    {
        public int OrderDeliveryId { get; set; }

        public int OrderItemOrderItemID { get; set; }

        public int CustomerAddressCustomerAddressID { get; set; }

        public int? DeliveryTypeDeliveryTypeID { get; set; }

        public int? DispatchWayBillNumber { get; set; }

        public DateTime? DispatchDate { get; set; }

        public string? WayBillNumber { get; set; }

        public int? FastTrackerNumber { get; set; }

        public DateTime? EstimateDeliveryDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string? Directions { get; set; }

        public string? IMEI { get; set; }

        public string? OrderNumber { get; set; }

        public string? DeliveryNote { get; set; }

        public string? PackageStatus { get; set; }

        public string? ReleaseForDespatch { get; set; }

        public string? PaymentRef { get; set; }

        public string? ConsignedFlag { get; set; }

        public string? RTS { get; set; }

        public string? RTSReason { get; set; }

        public string? RTSNote { get; set; }

        public string? ConsignmentID { get; set; }

        public virtual CustomerAddress CustomerAddress { get; set; }

        public virtual OrderItem OrderItem { get; set; }

        public virtual DeliveryType? DeliveryType { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}