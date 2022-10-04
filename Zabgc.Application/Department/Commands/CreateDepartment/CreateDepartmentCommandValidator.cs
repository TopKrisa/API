using FluentValidation;

namespace Zabgc.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(createDepartmentCommand
                => createDepartmentCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createDepartmentCommand =>
            createDepartmentCommand.Text).NotEmpty();
        }
    }
}
