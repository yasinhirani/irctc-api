using System.Globalization;
using FluentValidation;
using irctc.DTOs;

namespace irctc.Validations
{
    public class LiveStatusValidations : AbstractValidator<LiveStatusRequestDto>
    {
        public LiveStatusValidations()
        {
            RuleFor(x => x.TrainNo)
            .NotEmpty().WithMessage("Train No is required")
            .MinimumLength(5).WithMessage("Train No must be 5 numbers")
            .MaximumLength(5).WithMessage("Train No must not exceed 5 numbers")
            .Matches(@"^\d+$").WithMessage("Please enter a valid Train No");
            RuleFor(x => x.StartDay)
            .NotNull().WithMessage("Start Day is required")
            .GreaterThanOrEqualTo(0).WithMessage("Start Day must be greater than or equal to 0.")
            .LessThanOrEqualTo(2).WithMessage("Start Day must be less than or equal to 2.");
        }
        private bool BeValidDate(string date)
        {
            return DateTime.TryParseExact(
                date,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _
            );
        }
    }
}