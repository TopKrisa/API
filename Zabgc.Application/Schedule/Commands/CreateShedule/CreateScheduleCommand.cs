using MediatR;
using System;
using Zabgc.Domain.Models;

namespace Zabgc.Application.Schedule.Commands.CreateShedule
{
    public class CreateScheduleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ScheduleTypeId { get; set; }
    }
}
