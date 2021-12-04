using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.Materials;

namespace Triquetra.Core.Handlers.Queries
{
    public class GetAllMaterialUnitsQuery : IRequest<IEnumerable<MaterialUnitDTO>>
    {
    }

    public class GetAllMaterialUnitsQueryHandler : IRequestHandler<GetAllMaterialUnitsQuery, IEnumerable<MaterialUnitDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetAllMaterialUnitsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialUnitDTO>> Handle(GetAllMaterialUnitsQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.MaterialUnits.GetAll());
            return _mapper.Map<IEnumerable<MaterialUnitDTO>>(entities);
        }
    }
}