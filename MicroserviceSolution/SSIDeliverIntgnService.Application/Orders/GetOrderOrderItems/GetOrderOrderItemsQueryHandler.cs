using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Domain.Entities;
using SSIDeliverIntgnService.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.GetOrderOrderItems
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetOrderOrderItemsQueryHandler : IRequestHandler<GetOrderOrderItemsQuery, List<OrderOrderItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetOrderOrderItemsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<OrderOrderItemDto>> Handle(GetOrderOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _orderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Order)} of Id '{request.OrderId}' could not be found");
            }
            return aggregateRoot.OrderItems.MapToOrderOrderItemDtoList(_mapper);
        }
    }
}