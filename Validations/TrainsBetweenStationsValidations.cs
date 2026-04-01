using FluentValidation;
using irctc.DTOs;

namespace irctc.Validations
{
    public class TrainsBetweenStationsValidations : AbstractValidator<TrainsBetweenStationRequestDto>
    {
        public TrainsBetweenStationsValidations()
        {
            RuleFor(x => x.From)
            .NotEmpty().WithMessage("From station code is required");
            RuleFor(x => x.To)
            .NotEmpty().WithMessage("To station code is required");
        }
    }
}