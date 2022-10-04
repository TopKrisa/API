using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Domain.Models;

namespace Zabgc.Application.News.Queries.GetNoteDetails
{
    public class NewsDetailsVm : IMapWith<Domain.Models.News>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
        public string PosterUrl { get; set; } 
        public string Description { get; set; }
        public string Message { get; set; } 
        public Guid NewsCategoryId { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Domain.Models.News, NewsDetailsVm>()
                .ForMember(news => news.Name,
                opt => opt.MapFrom(news => news.Name))
                .ForMember(news => news.Message,
                opt => opt.MapFrom(news => news.Message))
                .ForMember(news => news.PosterUrl,
                opt => opt.MapFrom(news => news.PosterUrl))
                .ForMember(news => news.Description,
                opt => opt.MapFrom(news => news.Description))
                .ForMember(news => news.CreationDate,
                opt => opt.MapFrom(news => news.CreationDate))
                .ForMember(news => news.EditionDate,
                opt => opt.MapFrom(news => news.EditionDate))
                .ForMember(news => news.NewsCategoryId,
                opt => opt.MapFrom(news => news.NewsCategoryId));
        }
    }
}
