using MediatR;
using System;

namespace Zabgc.Application.ScheduleType.Commands
{
    public class CreateScheduleTypeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
