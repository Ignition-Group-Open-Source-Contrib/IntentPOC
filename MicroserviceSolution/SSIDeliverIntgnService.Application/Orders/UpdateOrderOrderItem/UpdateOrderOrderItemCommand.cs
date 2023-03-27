using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.UpdateOrderOrderItem
{
    public class UpdateOrderOrderItemCommand : IRequest, ICommand
    {
        public string OrderId { get; set; }

        public Guid Id { get; set; }

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

    }
}