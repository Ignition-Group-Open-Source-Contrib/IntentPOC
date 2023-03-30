using IDeliverService.Application.CreateProduct;
using IDeliverService.Application.CreateSaleOrder;
using IDeliverService.Application.GetProduct;
using IDeliverService.Application.GetSaleOrder;
using IDeliverService.Application.GetTrackingEvents;
using IDeliverService.Application.GetTrackingPOD;
using IDeliverService.Application.SalesChannels;
using IDeliverService.Application.UpdateProduct;
using IDeliverService.Application.UpdateSaleOrder;
using IDeliverService.Application.UpdateSaleOrderStatus;
using IDeliverService.Application.ViewModels;
using IDeliverService.Application.Warehouses;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace IDeliverService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IDeliverController : ControllerBase
    {
        private readonly ISender _mediator;

        public IDeliverController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;SaleChannelsResponseModel&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(List<SaleChannelsResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SaleChannelsResponseModel>>> SalesChannels(string token, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new SalesChannels { Token = token }, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified TrackingPODResponseModel.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an TrackingPODResponseModel with the parameters provided.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(TrackingPODResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrackingPODResponseModel>> GetTrackingPOD(int id, string token, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetTrackingPOD { Id = id, Token = token }, cancellationToken);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(GetSaleOrderResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetSaleOrderResponseModel>> UpdateSaleOrderStatus(string token, int id, [FromBody] UpdateOrderStatusRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateSaleOrderStatus { Token = token, Id = id, Request = request }, cancellationToken);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified TrackingEventsResponseModel.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an TrackingEventsResponseModel with the parameters provided.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(TrackingEventsResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrackingEventsResponseModel>> GetTrackingEvents(string token, int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetTrackingEvents { Token = token, Id = id }, cancellationToken);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;WarehouseResponseModel&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(List<WarehouseResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<WarehouseResponseModel>>> Warehouses(string token, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new Warehouses { Token = token }, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified CreateProductResponseModel.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an CreateProductResponseModel with the parameters provided.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(CreateProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductResponseModel>> GetProduct(string token, string sku, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetProduct { Token = token, Sku = sku }, cancellationToken);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductResponseModel>> CreateProduct(string token, [FromBody] CreateProductRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new CreateProduct { Token = token, Request = request }, cancellationToken);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductResponseModel>> UpdateProduct(string token, string sku, [FromBody] UpdateProductRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProduct { Token = token, Sku = sku, Request = request }, cancellationToken);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified GetSaleOrderResponseModel.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an GetSaleOrderResponseModel with the parameters provided.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(GetSaleOrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetSaleOrderResponseModel>> GetSaleOrder(string token, int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetSaleOrder { Token = token, Id = id }, cancellationToken);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateUpdateSaleOrderRequestModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUpdateSaleOrderRequestModel>> CreateSaleOrder(string token, [FromBody] CreateUpdateSaleOrderRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new CreateSaleOrder { Token = token, Request = request }, cancellationToken);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateUpdateSaleOrderResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUpdateSaleOrderResponseModel>> UpdateSaleOrder(string token, int id, [FromBody] CreateUpdateSaleOrderRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new UpdateSaleOrder { Token = token, Id = id, Request = request }, cancellationToken);
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}