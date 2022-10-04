using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.News.Queries.GetNewsList
{
    public class NewsLookupDto : IMapWith<Domain.Models.News>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Guid NewsCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Zabgc.Domain.Models.News, NewsLookupDto>()
                    .ForMember(newsDto => newsDto.Name,
                    opt => opt.MapFrom(news => news.Name))
                    .ForMember(newsDto => newsDto.PosterUrl,
                    opt => opt.MapFrom(news => news.PosterUrl))
                    .ForMember(newsDto => newsDto.Description,
                    opt => opt.MapFrom(news => news.Description))
                    .ForMember(newsDto => newsDto.CreationDate,
                    opt => opt.MapFrom(news => news.CreationDate))
                    .ForMember(newsDto=> newsDto.Message,
                    opt=> opt.MapFrom(news=> news.Message))
                    .ForMember(newsDto=> newsDto.NewsCategoryId,
                    opt=> opt.MapFrom(news=> news.NewsCategoryId));
        }

    }
}
