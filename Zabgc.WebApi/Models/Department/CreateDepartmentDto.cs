using AutoMapper;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Department.Commands.CreateDepartment;

namespace Zabgc.WebApi.Models.Department
{
    public class CreateDepartmentDto : IMapWith<CreateDepartmentCommand>
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentDto, CreateDepartmentCommand>()
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name));
        }
    }
}
