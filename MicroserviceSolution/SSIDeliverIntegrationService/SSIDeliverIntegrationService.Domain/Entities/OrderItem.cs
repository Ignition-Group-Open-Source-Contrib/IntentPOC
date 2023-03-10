using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int? DocumentId { get; set; }

        public int Smssent { get; set; }

        public int Faxsent { get; set; }

        public int BuyOut { get; set; }

        public string SuspendCode { get; set; }

        public string DeliveryInstruction { get; set; }

        public string DocumentationCompleted { get; set; }

        public int Ricaindicator { get; set; }

        public string ItemEscalation { get; set; }

        public string ThirdPartyReference { get; set; }

        public decimal Price { get; set; }

        public string OrderReference { get; set; }

        public int OrderItemNumber { get; set; }

        public int? CustomerBankId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public int? OrderCancelReasonDetailId { get; set; }

        public int OrderTypeId { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? ProviderRef { get; set; }

        public int? VasRef { get; set; }

        public int? BankRef { get; set; }

        public int? BundleId { get; set; }

        public int? BundleRef { get; set; }

        public int PayMethodId { get; set; }

        public int? FaisUserId { get; set; }

        public int? RelatedOrderItemId { get; set; }

        public int? MsorderId { get; set; }

        public int? EmorderId { get; set; }

        public DateTime? OperationDate { get; set; }

        public int? LastUpdatedByUserId { get; set; }

        public DateTime? StatusChangeDate { get; set; }

        public string TinyUrl { get; set; }

        public int? FreemiumOrderItemId { get; set; }

        public bool? IsMarketic { get; set; }

        public int OrderId { get; set; }

        public int DealDealId { get; set; }

        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

        protected virtual ICollection<StockItem> StockItems { get; set; }

        public virtual Deal Deal { get; set; }
    }
}