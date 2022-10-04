using FluentValidation;

namespace Zabgc.Application.NewsPapper.Commands.CreateNewsPapper
{
    public class CreateNewsPapperCommandValidator : AbstractValidator<CreateNewsPapperCommand>
    {
        public CreateNewsPapperCommandValidator()
        {
            RuleFor(createNewsPapperCommand =>
            createNewsPapperCommand.Date).NotEmpty();
            RuleFor(createNewsPapperCommand =>
            createNewsPapperCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createNewsPapperCommand =>
            createNewsPapperCommand.Url).NotEmpty();
        }
    }
}
