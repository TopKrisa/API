using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.News.Commands.UpdateNews;


namespace Zabgc.WebApi.Models.News
{
    public class UpdateNewsDto : IMapWith<UpdateNewsCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Zabgc.Domain.Models.NewsCategory NewsCategory { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNewsCommand>()
                .ForMember(news => news.Id,
                opt => opt.MapFrom(news => news.Id))
                .ForMember(news => news.Name,
                opt => opt.MapFrom(news => news.Name))
                .ForMember(news => news.PosterUrl,
                opt => opt.MapFrom(news => news.PosterUrl))
                .ForMember(news => news.Description,
                opt => opt.MapFrom(news => news.Description))
                .ForMember(news => news.Message,
                opt => opt.MapFrom(news => news.Message))
                .ForMember(news => news.NewsCategoryId,
                opt => opt.MapFrom(news => news.NewsCategory));
        }
    }
}
