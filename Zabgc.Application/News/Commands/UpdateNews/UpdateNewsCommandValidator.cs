using FluentValidation;

namespace Zabgc.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(updateNewsCommand =>
            updateNewsCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateNewsCommand =>
            updateNewsCommand.Message).NotEmpty();
            RuleFor(updateNewsCommand =>
            updateNewsCommand.Description).MaximumLength(250);
            RuleFor(updateNewsCommand =>
            updateNewsCommand.NewsCategoryId).NotEmpty();
        }
    }
}
