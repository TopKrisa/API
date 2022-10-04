using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.News.Commands.CreateNews;

namespace Zabgc.WebApi.Models.News
{
    public class CreateNewsDto : IMapWith<CreateNewsCommand>
    {
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Guid NewsCategoryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsCommand>()
                .ForMember(news => news.Name,
                opt => opt.MapFrom(news => news.Name))
                .ForMember(news => news.PosterUrl,
                opt => opt.MapFrom(news => news.PosterUrl))
                .ForMember(news => news.Description,
                opt => opt.MapFrom(news => news.Description))
                .ForMember(news => news.Message,
                opt => opt.MapFrom(news => news.Message))
                .ForMember(news => news.NewsCategoryId,
                opt => opt.MapFrom(news => news.NewsCategoryId));
        }
    }
}
