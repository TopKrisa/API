using FluentValidation;
using System;

namespace Zabgc.Application.Schedule.Commands.CreateShedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(createScheduleCommand =>
            createScheduleCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createScheduleCommand =>
            createScheduleCommand.Url).NotEmpty();
            RuleFor(createScheduleCommand =>
            createScheduleCommand.ScheduleTypeId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
