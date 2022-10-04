using AutoMapper;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.NewsCategory.Commands.CreateNewsCategory;

namespace Zabgc.WebApi.Models.NewsCategory
{
    public class CreateNewsCategoryDto : IMapWith<CreateNewsCategoryCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsCategoryDto, CreateNewsCategoryCommand>()
                .ForMember(nc => nc.Name,
                opt => opt.MapFrom(nc => nc.Name))
                .ForMember(nc => nc.Description,
                opt => opt.MapFrom(nc => nc.Description));
        }
    }
}
