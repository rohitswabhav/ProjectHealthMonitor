using FluentValidation;
using ProjectHealthMonitor.DTOs;

namespace ProjectHealthMonitor.Validation
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Budget)
                .GreaterThan(0);

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be after start date");
        }
    }
    public class UpdateProgressValidator : AbstractValidator<UpdateProgressRequest>
    {
        public UpdateProgressValidator()
        {
            RuleFor(x => x.ProgressPercentage)
                .InclusiveBetween(0, 100);
        }
    }
}