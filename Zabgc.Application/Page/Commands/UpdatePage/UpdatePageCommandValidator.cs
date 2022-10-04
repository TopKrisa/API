using FluentValidation;

namespace Zabgc.Application.Page.Commands.UpdatePage
{
    public class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommand>
    {
        public UpdatePageCommandValidator()
        {
            RuleFor(updatePageCommand =>
            updatePageCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updatePageCommand =>
            updatePageCommand.PageCategoryId).NotEmpty();
            RuleFor(updatePageCommand =>
            updatePageCommand.Text).NotEmpty();
        }
    }
}
