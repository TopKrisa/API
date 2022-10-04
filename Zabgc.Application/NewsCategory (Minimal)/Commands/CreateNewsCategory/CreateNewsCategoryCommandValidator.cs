using FluentValidation;

namespace Zabgc.Application.NewsCategory.Commands.CreateNewsCategory
{
    public class CreateNewsCategoryCommandValidator : AbstractValidator<CreateNewsCategoryCommand>
    {
        public CreateNewsCategoryCommandValidator()
        {
            RuleFor(createNewsCategory =>
            createNewsCategory.Name).NotEmpty().MaximumLength(50);
            RuleFor(createNewsCategory =>
            createNewsCategory.Description).NotEmpty().MaximumLength(256);
        }
    }
}
