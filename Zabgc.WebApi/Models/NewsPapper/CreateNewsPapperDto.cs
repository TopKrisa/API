using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.NewsPapper.Commands.CreateNewsPapper;

namespace Zabgc.WebApi.Models.NewsPapper
{
    public class CreateNewsPapperDto : IMapWith<CreateNewsPapperCommand>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsPapperDto, CreateNewsPapperCommand>()
                .ForMember(np => np.Name,
                opt => opt.MapFrom(np => np.Name))
                .ForMember(np => np.Url,
                opt => opt.MapFrom(np => np.Url))
                .ForMember(np => np.Date,
                opt => opt.MapFrom(np => np.Date));
        }
    }
}
