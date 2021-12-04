using MediatR;
using Triquetra.Domain.DTO;
using Triquetra.Domain.Data;
using Triquetra.Core.Exceptions;
using AutoMapper;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Providers.Handlers.Queries
{
    public class GetContractByIdQuery : IRequest<ContractDTO>
    {
        public int ContractId { get; }

        public GetContractByIdQuery(int ContractId)
        {
            ContractId = ContractId;
        }
    }

    public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, ContractDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetContractByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContractDTO> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
        {
            var Contract = await Task.FromResult(_repository.Contracts.Get(request.ContractId));

            if (Contract == null)
            {
                throw new EntityNotFoundException($"No Contract found for Id {request.ContractId}");
            }

            return _mapper.Map<ContractDTO>(Contract);
        }
    }
}