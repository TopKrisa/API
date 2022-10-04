using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Schedule.Commands.UpdateSchedule;
using Zabgc.Domain.Models;

namespace Zabgc.WebApi.Models.Schedule
{
    public class UpdateScheduleDto : IMapWith<UpdateScheduleCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ScheduleTypeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateScheduleDto, UpdateScheduleCommand>()
                .ForMember(sch=> sch.Id,
                opt=> opt.MapFrom(sch=> sch.Id))
                .ForMember(sch => sch.Name,
                opt => opt.MapFrom(sch => sch.Name))
                .ForMember(sch => sch.Url,
                opt => opt.MapFrom(sch => sch.Url))
                .ForMember(sch => sch.ScheduleTypeId,
                opt => opt.MapFrom(sch => sch.ScheduleTypeId));
        }
    }
}
