using AutoMapper;
using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Core.Handlers.Queries
{
    public class GetAllContractsQuery : IRequest<IEnumerable<ContractDTO>>
    {
    }

    public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, IEnumerable<ContractDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllContractsQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractDTO>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Contracts.GetAll());
            return _mapper.Map<IEnumerable<ContractDTO>>(entities);
        }
    }
}