using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Triquetra.Core.Exceptions;
using Triquetra.Core.Handlers.Commands;
using Triquetra.Core.Handlers.Queries;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Contracts;
using Triquetra.Domain.DTO.Products;

namespace Triquetra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ProductDTO>), (int) HttpStatusCode.OK)]
        //[ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            //return Ok(response);
            return response;
        }

        //TODO: Test Edilecek
        [HttpPost]
        [ProducesResponseType(typeof(int), (int) HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateProductDTO model)
        {
            try
            {
                var command = new CreateProductCommand(model);
                var response = await _mediator.Send(command);
                return StatusCode((int) HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
    }
}