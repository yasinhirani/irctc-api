using FluentValidation;

namespace irctc.Validations
{
    public class TrainInfoValidations : AbstractValidator<string>
    {
        public TrainInfoValidations()
        {
            RuleFor(x => x)
            .NotEmpty().WithMessage("Train No is required")
            .MinimumLength(5).WithMessage("Train No must be 5 numbers")
            .MaximumLength(5).WithMessage("Train No must not exceed 5 numbers")
            .Matches(@"^\d+$").WithMessage("Please enter a valid Train No");
        }
    }
}