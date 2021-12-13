using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Triquetra.Core.Exceptions;
using Triquetra.Core.Handlers.Commands;
using Triquetra.Core.Handlers.Queries;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.ProductTypes;

namespace Triquetra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductTypeDTO>> Get()
        {
            var query = new GetAllProductTypesQuery();
            var response = await _mediator.Send(query);
            return response;
        }
    }
}