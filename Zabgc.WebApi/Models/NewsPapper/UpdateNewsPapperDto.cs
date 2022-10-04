using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.NewsPapper.Commands.UpdateNewsPapper;

namespace Zabgc.WebApi.Models.NewsPapper
{
    public class UpdateNewsPapperDto : IMapWith<UpdateNewsPapperCommand>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsPapperDto, UpdateNewsPapperCommand>()
                .ForMember(np => np.Name,
                opt => opt.MapFrom(np => np.Name))
                .ForMember(np => np.Url,
                opt => opt.MapFrom(np => np.Url))
                .ForMember(np => np.Date,
                opt => opt.MapFrom(np => np.Date));
        }
    }
}
