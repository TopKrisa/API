using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.ScheduleType.Queries.GetScheduleTypeList
{
    public class ScheduleTypeLookupDto : IMapWith<Domain.Models.ScheduleType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.ScheduleType, ScheduleTypeLookupDto>()
                .ForMember(st => st.Id,
                opt => opt.MapFrom(st => st.Id))
                .ForMember(st => st.Name,
                opt => opt.MapFrom(st => st.Name));
        }
    }
}
