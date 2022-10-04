using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Page.Queries.GetPageList
{
    public class PageLookupDto : IMapWith<Domain.Models.Page>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid PageCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Page, PageLookupDto>()
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name))
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept=> dept.PageCategoryId,
                opt=> opt.MapFrom(dept=> dept.PageCategoryId));
        }
    }
}
