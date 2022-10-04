using System;
using FluentValidation; 

namespace Zabgc.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(createNewsCommand =>
            createNewsCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(createNoteCommand =>
            createNoteCommand.Message).NotEmpty();
            RuleFor(createNewsCommand =>
            createNewsCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createNewsCommand =>
            createNewsCommand.PosterUrl).NotEmpty();
            RuleFor(createNewsCommand =>
            createNewsCommand.NewsCategoryId).NotEmpty();
        }
    }
}
