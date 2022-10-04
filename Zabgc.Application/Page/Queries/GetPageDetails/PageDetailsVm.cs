using AutoMapper;
using System;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.Page.Queries.GetPageDetails
{
    public class PageDetailsVm : IMapWith<Domain.Models.Page>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid  PageCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditionDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Page, PageDetailsVm>()
                .ForMember(np => np.Id,
                opt => opt.MapFrom(np => np.Id))
                .ForMember(np => np.Name,
                opt => opt.MapFrom(np => np.Name))
                .ForMember(np => np.Text,
                opt => opt.MapFrom(np => np.Text))
                .ForMember(np => np.PageCategoryId,
                opt => opt.MapFrom(np => np.PageCategoryId))
                .ForMember(np => np.CreationDate,
                opt => opt.MapFrom(np => np.CreationDate))
                .ForMember(np => np.EditionDate,
                opt => opt.MapFrom(np => np.EditionDate));
        }
    }
}
