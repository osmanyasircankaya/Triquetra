using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Triquetra.Core.Handlers.Queries;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Contracts;
using Triquetra.Domain.DTO.Materials;

namespace Triquetra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialUnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MaterialUnitDTO>), (int) HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllMaterialUnitsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}