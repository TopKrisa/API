using MediatR;
using System;

namespace Zabgc.Application.Schedule.Commands.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
