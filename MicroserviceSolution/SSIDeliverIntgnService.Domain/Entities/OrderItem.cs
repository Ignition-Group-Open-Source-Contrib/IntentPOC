using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntgnService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderItem
    {
        private Guid? _id;

        public Guid Id
        {
            get => _id ??= Guid.NewGuid();
            set => _id = value;
        }

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

        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

        public virtual Order Order { get; set; }
    }
}