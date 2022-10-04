using FluentValidation;

namespace Zabgc.Application.ScheduleType.Commands
{
    public class CreateScheduleTypeCommandValidator : AbstractValidator<CreateScheduleTypeCommand>
    {
        public CreateScheduleTypeCommandValidator()
        {
            RuleFor(createScheduleTypeCommand =>
            createScheduleTypeCommand.Name).NotEmpty().MaximumLength(50);
        }
    }
}
