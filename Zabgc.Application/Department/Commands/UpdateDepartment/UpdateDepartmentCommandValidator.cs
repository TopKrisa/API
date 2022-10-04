using FluentValidation;

namespace Zabgc.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(updateDepartmentValidator =>
            updateDepartmentValidator.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateDepartmentValidator =>
            updateDepartmentValidator.Text).NotEmpty();
        }
    }
}
