using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DaprSwagger.Extensions;
using IgnProductCatalogueService.Api.Controllers.ResponseTypes;
using IgnProductCatalogueService.Application;
using IgnProductCatalogueService.Application.GetProductCatalogByFilter;
using IgnProductCatalogueService.Application.ProductCatalogues;
using IgnProductCatalogueService.Application.ProductCatalogues.CreateProductCatalogue;
using IgnProductCatalogueService.Application.ProductCatalogues.DeleteProductCatalogue;
using IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogueById;
using IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogues;
using IgnProductCatalogueService.Application.ProductCatalogues.UpdateProductCatalogue;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace IgnProductCatalogueService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCatalogueController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductCatalogueController(ISender mediator)
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
        public async Task<ActionResult<string>> Post([FromBody] CreateProductCatalogueCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified ProductCatalogueDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an ProductCatalogueDto with the parameters provided.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductCatalogueDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductCatalogueDto>> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductCatalogueByIdQuery { Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;ProductCatalogueDto&gt;.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductCatalogueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductCatalogueDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductCataloguesQuery(), cancellationToken);
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
        public async Task<ActionResult> Put([FromRoute] string id, [FromBody] UpdateProductCatalogueCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Delete([FromRoute] string id, [FromQuery] DeleteProductCatalogueCommand command, CancellationToken cancellationToken)
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
        /// <response code="200">Returns the specified List&lt;ProductCatalogueDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(List<ProductCatalogueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductCatalogueDto>>> GetProductCatalogByFilter([FromQuery] SearchQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductCatalogByFilterQuery { Request = request }, cancellationToken);
            return Ok(result);
        }
    }
}