using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Department.Commands.UpdateDepartment;

namespace Zabgc.WebApi.Models.Department
{
    public class UpdateDepartmentDto : IMapWith<UpdateDepartmentCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentDto, UpdateDepartmentCommand>()
                .ForMember(dept => dept.Id,
                opt=> opt.MapFrom(dept=> dept.Id))
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name));
        }
    }
}
