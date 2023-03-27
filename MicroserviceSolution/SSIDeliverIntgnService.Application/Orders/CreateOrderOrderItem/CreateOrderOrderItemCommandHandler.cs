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

namespace SSIDeliverIntgnService.Application.Orders.CreateOrderOrderItem
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateOrderOrderItemCommandHandler : IRequestHandler<CreateOrderOrderItemCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateOrderOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateOrderOrderItemCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _orderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Order)} of Id '{request.OrderId}' could not be found");
            }
            var newOrderItem = new OrderItem
            {
#warning No matching field found for OrderId
                DealId = request.DealId,
                SMSSent = request.SMSSent,
                FAXSent = request.FAXSent,
                BuyOut = request.BuyOut,
                SuspendCode = request.SuspendCode,
                DeliveryInstruction = request.DeliveryInstruction,
                DocumentationCompleted = request.DocumentationCompleted,
                RICAIndicator = request.RICAIndicator,
                ItemEscalation = request.ItemEscalation,
                ThirdPartyReference = request.ThirdPartyReference,
                OrderTypeId = request.OrderTypeId,
                Price = request.Price,
                OrderReference = request.OrderReference,
                OrderItemNumber = request.OrderItemNumber,
                CancelStatusDetailId = request.CancelStatusDetailId,
                ProviderRef = request.ProviderRef,
                VasRef = request.VasRef,
                BankRef = request.BankRef,
                BundleRef = request.BundleRef,
                RelatedOrderItemId = request.RelatedOrderItemId,
                MSOrderId = request.MSOrderId,
                EMOrderId = request.EMOrderId,
                OperationDate = request.OperationDate,
                LastUpdatedByUserId = request.LastUpdatedByUserId,
                StatusChangeDate = request.StatusChangeDate,
                TinyUrl = request.TinyUrl,
                IsMarketic = request.IsMarketic,
                FreemiumOrderItemId = request.FreemiumOrderItemId,
            };

            aggregateRoot.OrderItems.Add(newOrderItem);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _orderRepository.Update(p => p.Id == request.OrderId, aggregateRoot);
            return newOrderItem.Id;
        }
    }
}