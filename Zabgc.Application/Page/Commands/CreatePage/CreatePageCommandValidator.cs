using FluentValidation;

namespace Zabgc.Application.Page.Commands.CreatePage
{
    public class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
    {
        public CreatePageCommandValidator()
        {
            RuleFor(createPageCommand =>
            createPageCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createPageCommand =>
            createPageCommand.PageCategoryId).NotEmpty();
            RuleFor(createPageCommand =>
            createPageCommand.Text).NotEmpty();
        }
    }
}
