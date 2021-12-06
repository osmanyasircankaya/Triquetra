using Triquetra.Domain.DTO;
using FluentValidation;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Core.Validators
{
    public class CreateContractDTOValidator : AbstractValidator<CreateContractDTO>
    {
        public CreateContractDTOValidator()
        {
            RuleFor(x => x.Power).NotEmpty().WithMessage("Sözleşme Gücü Boş Bırakılmaz");
        }
    }
}
