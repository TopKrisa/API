using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.NewsCategory.Queries.GetNewsCategoryList
{
    public class NewsCategoryLookupDto : IMapWith<Domain.Models.NewsCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.NewsCategory, NewsCategoryLookupDto>()
                .ForMember(nc=> nc.Id,
                opt=> opt.MapFrom(nc=> nc.Id))
                .ForMember(nc => nc.Name,
                opt => opt.MapFrom(nc => nc.Name))
                .ForMember(nc => nc.Description,
                opt => opt.MapFrom(nc => nc.Description));
        }
    }
}
