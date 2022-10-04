using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Department.Queries.GetDepartmentDetails
{
    public class DepartmentDetailsVm : IMapWith<Domain.Models.Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime EditionDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Department, DepartmentDetailsVm>()
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name))
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept => dept.EditionDate,
                opt => opt.MapFrom(dept => dept.EditionDate))
                .ForMember(dept=> dept.Id,
                opt=> opt.MapFrom(dept=> dept.Id));
        }
    }
}