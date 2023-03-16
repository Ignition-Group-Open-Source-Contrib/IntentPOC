using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Deals;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderItem : IHasDomainEvent
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int DealId { get; set; }

        public int SMSSent { get; set; }

        public int FAXSent { get; set; }

        public int BuyOut { get; set; }

        public string? SuspendCode { get; set; }

        public string? DeliveryInstruction { get; set; }

        public int DocumentationCompleted { get; set; }

        public int RICAIndicator { get; set; }

        public string ItemEscalation { get; set; }

        public string? ThirdPartyReference { get; set; }

        public int OrderTypeId { get; set; }

        public decimal Price { get; set; }

        public string? OrderReference { get; set; }

        public int OrderItemNumber { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? ProviderRef { get; set; }

        public int? VasRef { get; set; }

        public int? BankRef { get; set; }

        public int? BundleRef { get; set; }

        public int? RelatedOrderItemId { get; set; }

        public int? MSOrderId { get; set; }

        public int? EMOrderId { get; set; }

        public DateTime? OperationDate { get; set; }

        public int? LastUpdatedByUserId { get; set; }

        public DateTime? StatusChangeDate { get; set; }

        public string? TinyUrl { get; set; }

        public bool? IsMarketic { get; set; }

        public int? FreemiumOrderItemId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public virtual OrderItem? FreemiumOrderItem { get; set; }

        public virtual Order Order { get; set; }

        public virtual Deal Deal { get; set; }

        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; } = new List<OrderDelivery>();

        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}