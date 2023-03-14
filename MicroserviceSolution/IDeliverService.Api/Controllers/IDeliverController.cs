using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDeliverService.Application;
using IDeliverService.Application.GetSalesChannel;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
        public async Task<ActionResult<List<SaleChannelsResponseModel>>> GetSalesChannel(string token, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetSalesChannel { Token = token }, cancellationToken);
            return Ok(result);
        }
    }
}