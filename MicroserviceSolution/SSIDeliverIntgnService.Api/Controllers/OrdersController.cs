using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SSIDeliverIntgnService.Api.Controllers.ResponseTypes;
using SSIDeliverIntgnService.Application.Orders;
using SSIDeliverIntgnService.Application.Orders.CreateOrder;
using SSIDeliverIntgnService.Application.Orders.CreateOrderOrderItem;
using SSIDeliverIntgnService.Application.Orders.DeleteOrder;
using SSIDeliverIntgnService.Application.Orders.DeleteOrderOrderItem;
using SSIDeliverIntgnService.Application.Orders.GetOrderById;
using SSIDeliverIntgnService.Application.Orders.GetOrderOrderItemById;
using SSIDeliverIntgnService.Application.Orders.GetOrderOrderItems;
using SSIDeliverIntgnService.Application.Orders.GetOrders;
using SSIDeliverIntgnService.Application.Orders.UpdateOrder;
using SSIDeliverIntgnService.Application.Orders.UpdateOrderOrderItem;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace SSIDeliverIntgnService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrdersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Post([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified OrderDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an OrderDto with the parameters provided.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;OrderDto&gt;.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<OrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrdersQuery(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromRoute] string id, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] string id, [FromQuery] DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("{orderId}/OrderItems")]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> PostOrderItem([FromRoute] string orderId, [FromBody] CreateOrderOrderItemCommand command, CancellationToken cancellationToken)
        {
            if (orderId != command.OrderId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified OrderOrderItemDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an OrderOrderItemDto with the parameters provided.</response>
        [HttpGet("{orderId}/OrderItems/{id}")]
        [ProducesResponseType(typeof(OrderOrderItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderOrderItemDto>> GetOrderItem([FromRoute] string orderId, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderOrderItemByIdQuery { OrderId = orderId, Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;OrderOrderItemDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("{orderId}/OrderItems")]
        [ProducesResponseType(typeof(List<OrderOrderItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<OrderOrderItemDto>>> GetAllOrderItems([FromRoute] string orderId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderOrderItemsQuery { OrderId = orderId }, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{orderId}/OrderItems/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutOrderItem([FromRoute] string orderId, [FromRoute] Guid id, [FromBody] UpdateOrderOrderItemCommand command, CancellationToken cancellationToken)
        {
            if (orderId != command.OrderId)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpDelete("{orderId}/OrderItems/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteOrderItem([FromRoute] string orderId, [FromRoute] Guid id, [FromQuery] DeleteOrderOrderItemCommand command, CancellationToken cancellationToken)
        {
            if (orderId != command.OrderId)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}