using FictionalCustomer.Core.Entitites;
using FluentValidation;

namespace FictionalCustomer.Core.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Company).NotEmpty().WithMessage("A Customer/Company is required").Length(1, 30).WithMessage("Customer/Company must be between 1 - 30 characters long");
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Project Title is required").Length(1, 30).WithMessage("Project Name must be between 1 - 30 characters long");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("End Date is required").GreaterThan(x => x.StartDate).WithMessage("End Date must be later then Start Date");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start Date is required").LessThan(x => x.EndDate).WithMessage("Start Date must be earlier then End Date");
            RuleFor(x => x.ProjectBudget).NotEmpty().WithMessage("Budget is required").GreaterThan(0).ScalePrecision(4, 18);
        }
    }
}

