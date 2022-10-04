using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Department.Queries.GetDepartmentList
{
    public class DepartmentLookupDto : IMapWith<Domain.Models.Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Department, DepartmentLookupDto>()
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name))
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text));
        }

    }
}
