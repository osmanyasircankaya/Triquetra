using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO.Materials;

namespace Triquetra.Core.Handlers.Queries
{
    public class GetAllMaterialsQuery : IRequest<IEnumerable<MaterialDTO>>
    {
    }

    public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, IEnumerable<MaterialDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllMaterialsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Materials.GetAll());
            return _mapper.Map<IEnumerable<MaterialDTO>>(entities);
        }
    }
}