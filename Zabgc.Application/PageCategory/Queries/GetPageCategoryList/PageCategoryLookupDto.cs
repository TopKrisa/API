using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.PageCategory.Queries.GetPageCategoryList
{
    public class PageCategoryLookupDto : IMapWith<Domain.Models.PageCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.PageCategory, PageCategoryLookupDto>()
                .ForMember(pc => pc.Id,
                opt => opt.MapFrom(pc => pc.Id))
                .ForMember(pc => pc.Description,
                opt => opt.MapFrom(pc => pc.Description))
                .ForMember(pc => pc.Name,
                opt => opt.MapFrom(pc => pc.Name));
        }
    }
}
