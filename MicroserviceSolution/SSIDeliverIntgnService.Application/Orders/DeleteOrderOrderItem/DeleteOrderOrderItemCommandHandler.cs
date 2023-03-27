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

namespace SSIDeliverIntgnService.Application.Orders.DeleteOrderOrderItem
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteOrderOrderItemCommandHandler : IRequestHandler<DeleteOrderOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteOrderOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteOrderOrderItemCommand request, CancellationToken cancellationToken)
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
            aggregateRoot.OrderItems.Remove(element);
            _orderRepository.Update(p => p.Id == request.OrderId, aggregateRoot);
            return Unit.Value;
        }
    }
}