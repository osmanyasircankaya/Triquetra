using MediatR;
using Triquetra.Domain.Data;
using Triquetra.Domain.DTO;
using Triquetra.Domain.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Providers.Handlers.Commands
{
    public class CreateContractCommand : IRequest<int>
    {
        public CreateContractDTO Model { get; }

        public CreateContractCommand(CreateContractDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateContractDTO> _validator;

        public CreateContractCommandHandler(IUnitOfWork repository, IValidator<CreateContractDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            CreateContractDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Contract
            {
                PanelPower = model.PanelPower,
                Power = model.Power,
                Price = model.Price,
                Cost = model.Cost,
                RoofSize = model.RoofSize
            };

            _repository.Contracts.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}