using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.Page.Commands.UpdatePage;

namespace Zabgc.WebApi.Models.Page
{
    public class UpdatePageDto : IMapWith<UpdatePageCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePageDto, UpdatePageCommand>()
                .ForMember(dept => dept.Id,
                opt => opt.MapFrom(dept => dept.Id))
                .ForMember(dept => dept.Text,
                opt => opt.MapFrom(dept => dept.Text))
                .ForMember(dept => dept.Name,
                opt => opt.MapFrom(dept => dept.Name));
        }
    }
}
