using FluentValidation;
using ProjectHealthMonitor.DTOs;

namespace ProjectHealthMonitor.Validation
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Budget)
                .GreaterThan(0);

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate);
        }
    }
}
