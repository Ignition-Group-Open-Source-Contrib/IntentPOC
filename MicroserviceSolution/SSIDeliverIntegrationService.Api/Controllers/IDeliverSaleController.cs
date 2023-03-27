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
using SSIDeliverIntegrationService.Application.GetSaleChannels;
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
    }
}