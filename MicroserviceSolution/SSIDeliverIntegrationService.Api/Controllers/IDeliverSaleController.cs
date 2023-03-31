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
using SSIDeliverIntegrationService.Application;
using SSIDeliverIntegrationService.Application.CreateProductOnIDeliver;
using SSIDeliverIntegrationService.Application.GetSaleChannels;
using SSIDeliverIntegrationService.Application.PlaceSaleOnIDeliver;
using SSIDeliverIntegrationService.Application.UpdateProductOnIDeliver;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace SSIDeliverIntegrationService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IDeliverSaleController : ControllerBase
    {
        private readonly ISender _mediator;

        public IDeliverSaleController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;SaleChannelsResponseModel&gt;.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(List<SaleChannelsResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SaleChannelsResponseModel>>> GetSaleChannels(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetSaleChannels(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PlaceSaleOnIDeliver(int orderId, List<int> orderItemIds, CancellationToken cancellationToken)
        {
            await _mediator.Send(new PlaceSaleOnIDeliver { OrderId = orderId, OrderItemIds = orderItemIds }, cancellationToken);
            return Created(string.Empty, null);
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductResponseModel>> UpdateProductOnIDeliver(int productId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateProductOnIDeliver { ProductId = productId }, cancellationToken);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(CreateProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateProductResponseModel>> CreateProductOnIDeliver(int productId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateProductOnIDeliver { ProductId = productId }, cancellationToken);
            return Created(string.Empty, result);
        }
    }
}