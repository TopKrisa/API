using MediatR;
using System;

namespace Zabgc.Application.Schedule.Queries.GetScheduleList
{
    public class GetScheduleListQuery : IRequest<ScheduleListVm>
    {
        public Guid Id { get; set; }
    }
}
