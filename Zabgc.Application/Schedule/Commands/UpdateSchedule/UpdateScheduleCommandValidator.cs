using FluentValidation;
using System;

namespace Zabgc.Application.Schedule.Commands.UpdateSchedule
{
    public class UpdateScheduleCommandValidator : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleCommandValidator()
        {
            RuleFor(updateScheduleCommand =>
            updateScheduleCommand.ScheduleTypeId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(updateScheduleCommand =>
            updateScheduleCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateScheduleCommand =>
            updateScheduleCommand.Url).NotEmpty();
        }
    }
}
