using FluentValidation;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    /// <summary>
    /// Class that manages the basic validation of the fields of the Role class. 
    /// Uses the FluentValidation nuget package.
    /// </summary>
    public class RoleValidation: AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(e => e.Id)
                .NotNull().WithMessage("Id cannot be null");

            RuleFor(e => e.Code)
                .NotNull().WithMessage("Code cannot be null")
                .NotEmpty().WithMessage("Code cannot be empaty")
                .MaximumLength(20).WithMessage("Code cannot be greater than 20 characters");

            RuleFor(e => e.Name)
                .NotNull().WithMessage("Name cannot be null")
                .NotEmpty().WithMessage("Name cannot be empaty")
                .MaximumLength(50).WithMessage("Name cannot be greater than 50 characters");

            RuleFor(e => e.Status)
                .NotNull().WithMessage("Status cannot be null");

            RuleFor(e => e.Description)
                .NotNull().WithMessage("Description cannot be null")
                .MaximumLength(500).WithMessage("Description cannot be greater than 500 characters");
        }
    }
}
