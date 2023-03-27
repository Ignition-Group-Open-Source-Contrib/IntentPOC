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

namespace SSIDeliverIntgnService.Application.Orders.UpdateOrderOrderItem
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateOrderOrderItemCommandHandler : IRequestHandler<UpdateOrderOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateOrderOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateOrderOrderItemCommand request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _orderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Order)} of Id '{request.OrderId}' could not be found");
            }
            var element = aggregateRoot.OrderItems.FirstOrDefault(p => p.Id == request.Id);
            if (element == null)
            {
                throw new InvalidOperationException($"{nameof(OrderItem)} of Id '{request.Id}' could not be found associated with {nameof(Order)} of Id '{request.OrderId}'");
            }
#warning No matching field found for OrderId
            element.DealId = request.DealId;
            element.SMSSent = request.SMSSent;
            element.FAXSent = request.FAXSent;
            element.BuyOut = request.BuyOut;
            element.SuspendCode = request.SuspendCode;
            element.DeliveryInstruction = request.DeliveryInstruction;
            element.DocumentationCompleted = request.DocumentationCompleted;
            element.RICAIndicator = request.RICAIndicator;
            element.ItemEscalation = request.ItemEscalation;
            element.ThirdPartyReference = request.ThirdPartyReference;
            element.OrderTypeId = request.OrderTypeId;
            element.Price = request.Price;
            element.OrderReference = request.OrderReference;
            element.OrderItemNumber = request.OrderItemNumber;
            element.CancelStatusDetailId = request.CancelStatusDetailId;
            element.ProviderRef = request.ProviderRef;
            element.VasRef = request.VasRef;
            element.BankRef = request.BankRef;
            element.BundleRef = request.BundleRef;
            element.RelatedOrderItemId = request.RelatedOrderItemId;
            element.MSOrderId = request.MSOrderId;
            element.EMOrderId = request.EMOrderId;
            element.OperationDate = request.OperationDate;
            element.LastUpdatedByUserId = request.LastUpdatedByUserId;
            element.StatusChangeDate = request.StatusChangeDate;
            element.TinyUrl = request.TinyUrl;
            element.IsMarketic = request.IsMarketic;
            element.FreemiumOrderItemId = request.FreemiumOrderItemId;
            _orderRepository.Update(p => p.Id == request.OrderId, aggregateRoot);
            return Unit.Value;
        }
    }
}