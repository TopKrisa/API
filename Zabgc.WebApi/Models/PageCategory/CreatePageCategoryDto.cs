using AutoMapper;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.PageCategory.Commands;

namespace Zabgc.WebApi.Models.PageCategory
{
    public class CreatePageCategoryDto : IMapWith<CreatePageCategoryCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePageCategoryDto, CreatePageCategoryCommand>()
                .ForMember(pc => pc.Name,
                opt => opt.MapFrom(pc => pc.Name))
                .ForMember(pc => pc.Description,
                opt => opt.MapFrom(pc => pc.Description));
        }
    }
}
