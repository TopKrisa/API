using FluentValidation;

namespace Zabgc.Application.NewsPapper.Commands.UpdateNewsPapper
{
    public class UpdateNewsPapperCommandValidator : AbstractValidator<UpdateNewsPapperCommand>
    {
        public UpdateNewsPapperCommandValidator()
        {
            RuleFor(updateNewsPapperCommand =>
            updateNewsPapperCommand.Date).NotEmpty();
            RuleFor(updateNewsPapperCommand =>
            updateNewsPapperCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateNewsPapperCommand =>
            updateNewsPapperCommand.Url).NotEmpty();
        }
    }
}
