using FictionalCustomer.Core.Entitites;
using FluentValidation;

namespace FictionalCustomer.Core.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required").Length(1, 30).WithMessage("First Name must be within 1-30 characters long");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required").Length(1, 30).WithMessage("Last Name must be within 1-30 characters long");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Address is required").Length(1, 30).WithMessage("Email Address must be within 1-30 characters long");
            RuleFor(x => x.StackType).NotNull().WithMessage("You need to select a stack");
        }
    }
}
