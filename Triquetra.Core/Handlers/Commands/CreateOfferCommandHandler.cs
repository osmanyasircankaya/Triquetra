using FluentValidation;
using MediatR;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.Offers;

namespace Triquetra.Core.Handlers.Commands
{
    public class CreateOfferCommand : IRequest<int>
    {
        public CreateOfferDTO Model { get; }

        public CreateOfferCommand(CreateOfferDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateOfferDTO> _validator;

        public CreateOfferCommandHandler(IUnitOfWork repository, IValidator<CreateOfferDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Offer
            {
                SetupArea = model.SetupArea,
                PanelCount = model.PanelCount,
                InverterCount = model.InverterCount,
                TotalPriceDollar = model.TotalPriceDollar,
                TotalPriceTL = model.TotalPriceTL
            };

            _repository.Offers.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}