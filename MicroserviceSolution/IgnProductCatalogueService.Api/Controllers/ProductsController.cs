using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IgnProductCatalogueService.Api.Controllers.ResponseTypes;
using IgnProductCatalogueService.Application.ProductsAttributes;
using IgnProductCatalogueService.Application.ProductsAttributes.CreateProducts;
using IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsAttributes;
using IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsRelationships;
using IgnProductCatalogueService.Application.ProductsAttributes.DeleteProducts;
using IgnProductCatalogueService.Application.ProductsAttributes.DeleteProductsAttributes;
using IgnProductCatalogueService.Application.ProductsAttributes.DeleteProductsRelationships;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProducts;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProductsAttributes;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProductsAttributesById;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProductsById;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProductsRelationships;
using IgnProductCatalogueService.Application.ProductsAttributes.GetProductsRelationshipsById;
using IgnProductCatalogueService.Application.ProductsAttributes.UpdateProducts;
using IgnProductCatalogueService.Application.ProductsAttributes.UpdateProductsAttributes;
using IgnProductCatalogueService.Application.ProductsAttributes.UpdateProductsRelationships;
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
    public class ProductsController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateProductsCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified ProductsDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an ProductsDto with the parameters provided.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductsDto>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsByIdQuery { Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;ProductsDto&gt;.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductsDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
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
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UpdateProductsCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromQuery] DeleteProductsCommand command, CancellationToken cancellationToken)
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
        [HttpPost("{productsId}/Attributes")]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> PostAttributes([FromRoute] Guid productsId, [FromBody] CreateProductsAttributesCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified ProductsAttributesDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an ProductsAttributesDto with the parameters provided.</response>
        [HttpGet("{productsId}/Attributes/{id}")]
        [ProducesResponseType(typeof(ProductsAttributesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductsAttributesDto>> GetAttributes([FromRoute] Guid productsId, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsAttributesByIdQuery { ProductsId = productsId, Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;ProductsAttributesDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("{productsId}/Attributes")]
        [ProducesResponseType(typeof(List<ProductsAttributesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductsAttributesDto>>> GetAllAttributes([FromRoute] Guid productsId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsAttributesQuery { ProductsId = productsId }, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{productsId}/Attributes/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutAttributes([FromRoute] Guid productsId, [FromRoute] Guid id, [FromBody] UpdateProductsAttributesCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
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
        [HttpDelete("{productsId}/Attributes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAttributes([FromRoute] Guid productsId, [FromRoute] Guid id, [FromQuery] DeleteProductsAttributesCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
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

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("{productsId}/Relationships")]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> PostRelationships([FromRoute] Guid productsId, [FromBody] CreateProductsRelationshipsCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified ProductsRelationshipsDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an ProductsRelationshipsDto with the parameters provided.</response>
        [HttpGet("{productsId}/Relationships/{id}")]
        [ProducesResponseType(typeof(ProductsRelationshipsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductsRelationshipsDto>> GetRelationships([FromRoute] Guid productsId, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsRelationshipsByIdQuery { ProductsId = productsId, Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;ProductsRelationshipsDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("{productsId}/Relationships")]
        [ProducesResponseType(typeof(List<ProductsRelationshipsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductsRelationshipsDto>>> GetAllRelationships([FromRoute] Guid productsId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsRelationshipsQuery { ProductsId = productsId }, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{productsId}/Relationships/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutRelationships([FromRoute] Guid productsId, [FromRoute] Guid id, [FromBody] UpdateProductsRelationshipsCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
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
        [HttpDelete("{productsId}/Relationships/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteRelationships([FromRoute] Guid productsId, [FromRoute] Guid id, [FromQuery] DeleteProductsRelationshipsCommand command, CancellationToken cancellationToken)
        {
            if (productsId != command.ProductsId)
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