using FluentValidation;

namespace Zabgc.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(createCommentCommand =>
            createCommentCommand.Message).NotEmpty().MaximumLength(256);
        }
    }
}
