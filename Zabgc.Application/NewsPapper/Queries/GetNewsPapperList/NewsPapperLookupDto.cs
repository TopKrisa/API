using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.NewsPapper.Queries.GetNewsPapperList
{
    public class NewsPapperLookupDto : IMapWith<Domain.Models.Newspapper>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Newspapper, NewsPapperLookupDto>()
                .ForMember(np => np.Id,
                opt => opt.MapFrom(np => np.Id))
                .ForMember(np => np.Name,
                opt => opt.MapFrom(np => np.Name))
                .ForMember(np => np.Url,
                opt => opt.MapFrom(np => np.Url))
                .ForMember(np => np.Date,
                opt => opt.MapFrom(np => np.Date));
        }
    }
}
