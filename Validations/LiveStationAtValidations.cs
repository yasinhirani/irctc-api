using FluentValidation;

namespace irctc.Validations
{
    public class LiveStationAtValidations : AbstractValidator<string>
    {
        public LiveStationAtValidations()
        {
            RuleFor(x => x)
            .NotEmpty().WithMessage("Station code is required");
        }
    }
}