using Triquetra.Domain.DTO;
using FluentValidation;
using Triquetra.Domain.DTO.Offers;

namespace Triquetra.Core.Validators
{
    public class CreateOfferValidator : AbstractValidator<CreateOfferDTO>
    {
        public CreateOfferValidator()
        {
            RuleFor(x => x.SetupArea).GreaterThan(0).WithMessage("alan sıfırdan büyük olmalı");
        }
    }
}