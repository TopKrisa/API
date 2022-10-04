using FluentValidation;

namespace Zabgc.Application.PageCategory.Commands
{
    public class CreatePageCategoryCommandValidator : AbstractValidator<CreatePageCategoryCommand>
    {
        public CreatePageCategoryCommandValidator()
        {
            RuleFor(createPageCategory =>
            createPageCategory.Name).NotEmpty().MaximumLength(50);
            RuleFor(createPageCategory =>
            createPageCategory.Description).NotEmpty().MaximumLength(300);
        }
    }
}
