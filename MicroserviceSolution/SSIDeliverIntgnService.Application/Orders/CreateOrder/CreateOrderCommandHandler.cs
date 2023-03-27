using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Domain.Entities;
using SSIDeliverIntgnService.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.CreateOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new Order
            {
                OrderDate = request.OrderDate,
                DialerAgentId = request.DialerAgentId,
                Period = request.Period,
                Comments = request.Comments,
                BasketReference = request.BasketReference,
                EscalationIndex = request.EscalationIndex,
                DebitOrderDay = request.DebitOrderDay,
                CustomerId = request.CustomerId,
                BillingIsPaid = request.BillingIsPaid,
                BillingDate = request.BillingDate,
                MSOrdermasterId = request.MSOrdermasterId,
                EMOrdermasterId = request.EMOrdermasterId,
                Affordability = request.Affordability,
                Ctflag = request.Ctflag,
                OrderOdooId = request.OrderOdooId,
                OrderItems = request.OrderItems.Select(CreateOrderItem).ToList(),
                IDeliverOrderInfo = request.IDeliverOrderInfo != null ? CreateIDeliverOrderInfo(request.IDeliverOrderInfo) : null,
            };

            _orderRepository.Add(newOrder);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newOrder.Id;
        }

        [IntentManaged(Mode.Fully)]
        private static OrderItem CreateOrderItem(CreateOrderOrderItemDto dto)
        {
            return new OrderItem
            {
                DealId = dto.DealId,
                SMSSent = dto.SMSSent,
                FAXSent = dto.FAXSent,
                BuyOut = dto.BuyOut,
                SuspendCode = dto.SuspendCode,
                DeliveryInstruction = dto.DeliveryInstruction,
                DocumentationCompleted = dto.DocumentationCompleted,
                RICAIndicator = dto.RICAIndicator,
                ItemEscalation = dto.ItemEscalation,
                ThirdPartyReference = dto.ThirdPartyReference,
                Price = dto.Price,
                CancelStatusDetailId = dto.CancelStatusDetailId,
                ProviderRef = dto.ProviderRef,
                VasRef = dto.VasRef,
                BankRef = dto.BankRef,
                BundleRef = dto.BundleRef,
                OperationDate = dto.OperationDate,
                LastUpdatedByUserId = dto.LastUpdatedByUserId,
                StatusChangeDate = dto.StatusChangeDate,
                TinyUrl = dto.TinyUrl,
                IsMarketic = dto.IsMarketic,
                OrderTypeId = dto.OrderTypeId,
                OrderReference = dto.OrderReference,
                OrderItemNumber = dto.OrderItemNumber,
                RelatedOrderItemId = dto.RelatedOrderItemId,
                MSOrderId = dto.MSOrderId,
                EMOrderId = dto.EMOrderId,
                FreemiumOrderItemId = dto.FreemiumOrderItemId,
                OrderStatusHistories = dto.OrderStatusHistories.Select(CreateOrderStatusHistory).ToList(),
            };
        }

        [IntentManaged(Mode.Fully)]
        private static OrderStatusHistory CreateOrderStatusHistory(CreateOrderOrderItemOrderStatusHistoryDto dto)
        {
            return new OrderStatusHistory
            {
                Occured = dto.Occured,
                Annotation = dto.Annotation,
                CancelStatusDetailId = dto.CancelStatusDetailId,
                EMOrderStatusHistoryId = dto.EMOrderStatusHistoryId,
                MSOrderStatusHistoryId = dto.MSOrderStatusHistoryId,
                OrderStatusDetailId = dto.OrderStatusDetailId,
                EmailCommSentStatusId = dto.EmailCommSentStatusId,
                SmscommsSentStatusId = dto.SmscommsSentStatusId,
            };
        }

        [IntentManaged(Mode.Fully)]
        private static IDeliverOrderInfo CreateIDeliverOrderInfo(CreateOrderIDeliverOrderInfoDto dto)
        {
            return new IDeliverOrderInfo
            {
                CreatedByUSerId = dto.CreatedByUSerId,
                UpdatedByUserId = dto.UpdatedByUserId,
                CreatedOnDate = dto.CreatedOnDate,
                UpdatedOnDate = dto.UpdatedOnDate,
                CourierId = dto.CourierId,
            };
        }
    }
}