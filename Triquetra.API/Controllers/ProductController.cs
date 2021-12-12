using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}