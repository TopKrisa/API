using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Domain.Models;

namespace Zabgc.Application.Schedule.Queries.GetScheduleList
{ 
    public class ScheduleLookupDto : IMapWith<Domain.Models.Schedule>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public Guid ScheduleTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Schedule, ScheduleLookupDto>()
                .ForMember(s => s.Name,
                opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.Date,
                opt => opt.MapFrom(s => s.Date))
                .ForMember(s => s.Url,
                opt => opt.MapFrom(s => s.Url))
                .ForMember(s => s.ScheduleTypeId,
                opt => opt.MapFrom(s => s.ScheduleTypeId));
        }
    }
}
