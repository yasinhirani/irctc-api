using FluentValidation;

namespace irctc.Validations
{
    public class PnrValidations : AbstractValidator<string>
    {
        public PnrValidations()
        {
            RuleFor(x => x)
            .NotEmpty().WithMessage("PNR number is required")
            .MinimumLength(10).WithMessage("PNR number must be 10 numbers")
            .MaximumLength(10).WithMessage("PNR number must not exceed 10 numbers")
            .Matches(@"^\d+$").WithMessage("Please enter a valid PNR number");
        }
    }
}