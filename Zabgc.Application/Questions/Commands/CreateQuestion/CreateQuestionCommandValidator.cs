using FluentValidation;

namespace Zabgc.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Message).NotEmpty().MaximumLength(250);
        }
    }
}
