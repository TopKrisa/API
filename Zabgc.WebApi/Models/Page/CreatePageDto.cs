using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Page.Commands.CreatePage;

namespace Zabgc.WebApi.Models.Page
{
    public class CreatePageDto : IMapWith<CreatePageCommand>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid PageCategoryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePageDto, CreatePageCommand>()
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name))
                .ForMember(dept => dept.PageCategoryId,
                opt => opt.MapFrom(dept => dept.PageCategoryId));
        }
    }
}
