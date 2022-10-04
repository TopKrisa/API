using FluentValidation;

namespace Zabgc.Application.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Message).NotEmpty().MaximumLength(250);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Answer).NotEmpty().MaximumLength(250);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.AdminName).NotEmpty().MaximumLength(50);
        }
    }
}
