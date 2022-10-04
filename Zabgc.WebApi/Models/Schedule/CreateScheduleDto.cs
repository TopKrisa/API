using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Schedule.Commands.CreateShedule;
using Zabgc.Domain.Models;

namespace Zabgc.WebApi.Models.Schedule
{
    public class CreateScheduleDto : IMapWith<CreateScheduleCommand>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ScheduleTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateScheduleDto, CreateScheduleCommand>()
                .ForMember(sch => sch.Name,
                opt => opt.MapFrom(sch => sch.Name))
                .ForMember(sch => sch.Url,
                opt => opt.MapFrom(sch => sch.Url))
                .ForMember(sch => sch.ScheduleTypeId,
                opt => opt.MapFrom(sch => sch.ScheduleTypeId));
        }
    }
}
