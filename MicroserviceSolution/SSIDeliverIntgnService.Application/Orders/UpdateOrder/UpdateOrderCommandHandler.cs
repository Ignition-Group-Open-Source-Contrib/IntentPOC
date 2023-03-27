using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Domain.Common;
using SSIDeliverIntgnService.Domain.Entities;
using SSIDeliverIntgnService.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.UpdateOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);
            existingOrder.OrderDate = request.OrderDate;
            existingOrder.DialerAgentId = request.DialerAgentId;
            existingOrder.Period = request.Period;
            existingOrder.Comments = request.Comments;
            existingOrder.BasketReference = request.BasketReference;
            existingOrder.EscalationIndex = request.EscalationIndex;
            existingOrder.DebitOrderDay = request.DebitOrderDay;
            existingOrder.CustomerId = request.CustomerId;
            existingOrder.BillingIsPaid = request.BillingIsPaid;
            existingOrder.BillingDate = request.BillingDate;
            existingOrder.MSOrdermasterId = request.MSOrdermasterId;
            existingOrder.EMOrdermasterId = request.EMOrdermasterId;
            existingOrder.Affordability = request.Affordability;
            existingOrder.Ctflag = request.Ctflag;
            existingOrder.OrderOdooId = request.OrderOdooId;
            existingOrder.OrderItems = UpdateHelper.CreateOrUpdateCollection(existingOrder.OrderItems, request.OrderItems, (e, d) => e.Id == d.Id, CreateOrUpdateOrderItem);
            existingOrder.IDeliverOrderInfo = CreateOrUpdateIDeliverOrderInfo(existingOrder.IDeliverOrderInfo, request.IDeliverOrderInfo);
            _orderRepository.Update(p => p.Id == request.Id, existingOrder);
            return Unit.Value;
        }

        [IntentManaged(Mode.Fully)]
        private static OrderItem CreateOrUpdateOrderItem(OrderItem entity, UpdateOrderOrderItemDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            entity ??= new OrderItem();
            entity.DealId = dto.DealId;
            entity.SMSSent = dto.SMSSent;
            entity.FAXSent = dto.FAXSent;
            entity.BuyOut = dto.BuyOut;
            entity.SuspendCode = dto.SuspendCode;
            entity.DeliveryInstruction = dto.DeliveryInstruction;
            entity.DocumentationCompleted = dto.DocumentationCompleted;
            entity.RICAIndicator = dto.RICAIndicator;
            entity.ItemEscalation = dto.ItemEscalation;
            entity.ThirdPartyReference = dto.ThirdPartyReference;
            entity.OrderTypeId = dto.OrderTypeId;
            entity.Price = dto.Price;
            entity.OrderReference = dto.OrderReference;
            entity.OrderItemNumber = dto.OrderItemNumber;
            entity.CancelStatusDetailId = dto.CancelStatusDetailId;
            entity.ProviderRef = dto.ProviderRef;
            entity.VasRef = dto.VasRef;
            entity.BankRef = dto.BankRef;
            entity.BundleRef = dto.BundleRef;
            entity.RelatedOrderItemId = dto.RelatedOrderItemId;
            entity.MSOrderId = dto.MSOrderId;
            entity.EMOrderId = dto.EMOrderId;
            entity.OperationDate = dto.OperationDate;
            entity.LastUpdatedByUserId = dto.LastUpdatedByUserId;
            entity.StatusChangeDate = dto.StatusChangeDate;
            entity.TinyUrl = dto.TinyUrl;
            entity.IsMarketic = dto.IsMarketic;
            entity.FreemiumOrderItemId = dto.FreemiumOrderItemId;

            return entity;
        }

        [IntentManaged(Mode.Fully)]
        private static IDeliverOrderInfo CreateOrUpdateIDeliverOrderInfo(IDeliverOrderInfo entity, UpdateOrderIDeliverOrderInfoDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            entity ??= new IDeliverOrderInfo();
            entity.IDeliverOrderStatusDetailId = dto.IDeliverOrderStatusDetailId;
            entity.CreatedByUSerId = dto.CreatedByUSerId;
            entity.UpdatedByUserId = dto.UpdatedByUserId;
            entity.CreatedOnDate = dto.CreatedOnDate;
            entity.UpdatedOnDate = dto.UpdatedOnDate;
            entity.CourierId = dto.CourierId;

            return entity;
        }
    }
}