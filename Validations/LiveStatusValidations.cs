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
            RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required")
            .Must(BeValidDate).WithMessage("Date must be valid and in DD-MM-YYYY format.");
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