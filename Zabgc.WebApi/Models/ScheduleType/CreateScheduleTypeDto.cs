using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.ScheduleType.Commands;

namespace Zabgc.WebApi.Models.ScheduleType
{
    public class CreateScheduleTypeDto : IMapWith<CreateScheduleTypeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateScheduleTypeDto, CreateScheduleTypeCommand>()
                .ForMember(st => st.Name,
                opt => opt.MapFrom(st => st.Name));
        }
    }
}
