using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders
{

    public class CreateOrderOrderItemDto
    {
        public CreateOrderOrderItemDto()
        {
        }

        public static CreateOrderOrderItemDto Create(
            int dealId,
            int sMSSent,
            int fAXSent,
            int buyOut,
            string? suspendCode,
            string? deliveryInstruction,
            int documentationCompleted,
            int rICAIndicator,
            string itemEscalation,
            string? thirdPartyReference,
            decimal price,
            int? cancelStatusDetailId,
            int? providerRef,
            int? vasRef,
            int? bankRef,
            int? bundleRef,
            DateTime? operationDate,
            int? lastUpdatedByUserId,
            DateTime? statusChangeDate,
            string? tinyUrl,
            bool? isMarketic,
            int orderTypeId,
            string? orderReference,
            int orderItemNumber,
            int? relatedOrderItemId,
            int? mSOrderId,
            int? eMOrderId,
            int? freemiumOrderItemId,
            List<CreateOrderOrderItemOrderStatusHistoryDto> orderStatusHistories)
        {
            return new CreateOrderOrderItemDto
            {
                DealId = dealId,
                SMSSent = sMSSent,
                FAXSent = fAXSent,
                BuyOut = buyOut,
                SuspendCode = suspendCode,
                DeliveryInstruction = deliveryInstruction,
                DocumentationCompleted = documentationCompleted,
                RICAIndicator = rICAIndicator,
                ItemEscalation = itemEscalation,
                ThirdPartyReference = thirdPartyReference,
                Price = price,
                CancelStatusDetailId = cancelStatusDetailId,
                ProviderRef = providerRef,
                VasRef = vasRef,
                BankRef = bankRef,
                BundleRef = bundleRef,
                OperationDate = operationDate,
                LastUpdatedByUserId = lastUpdatedByUserId,
                StatusChangeDate = statusChangeDate,
                TinyUrl = tinyUrl,
                IsMarketic = isMarketic,
                OrderTypeId = orderTypeId,
                OrderReference = orderReference,
                OrderItemNumber = orderItemNumber,
                RelatedOrderItemId = relatedOrderItemId,
                MSOrderId = mSOrderId,
                EMOrderId = eMOrderId,
                FreemiumOrderItemId = freemiumOrderItemId,
                OrderStatusHistories = orderStatusHistories,
            };
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

        public decimal Price { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? ProviderRef { get; set; }

        public int? VasRef { get; set; }

        public int? BankRef { get; set; }

        public int? BundleRef { get; set; }

        public DateTime? OperationDate { get; set; }

        public int? LastUpdatedByUserId { get; set; }

        public DateTime? StatusChangeDate { get; set; }

        public string? TinyUrl { get; set; }

        public bool? IsMarketic { get; set; }

        public int OrderTypeId { get; set; }

        public string? OrderReference { get; set; }

        public int OrderItemNumber { get; set; }

        public int? RelatedOrderItemId { get; set; }

        public int? MSOrderId { get; set; }

        public int? EMOrderId { get; set; }

        public int? FreemiumOrderItemId { get; set; }

        public List<CreateOrderOrderItemOrderStatusHistoryDto> OrderStatusHistories { get; set; }

    }
}