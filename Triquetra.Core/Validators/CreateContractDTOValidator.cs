using Triquetra.Domain.DTO;
using FluentValidation;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Core.Validators
{
    public class CreateContractDTOValidator : AbstractValidator<CreateContractDTO>
    {
        public CreateContractDTOValidator()
        {
            RuleFor(x => x.Cost).NotEmpty().WithMessage("Bedel ödemelisin");
        }
    }
}
