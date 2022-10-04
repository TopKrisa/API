using AutoMapper;
using System.Collections.Generic;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.PhotoAlbum.Commands.CreatePhotoAlbum;
using Zabgc.Domain.Models;

namespace Zabgc.WebApi.Models.PhotoAlbum
{
    public class CreatePhotoAlbumDto : IMapWith<CreatePhotoAlbumCommand>
    {
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Domain.Models.Department Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhotoAlbumDto, CreatePhotoAlbumCommand>()
                .ForMember(pa => pa.Photos,
                opt => opt.MapFrom(pa => pa.Photos))
                .ForMember(pa => pa.Name,
                opt => opt.MapFrom(pa => pa.Name))
                .ForMember(pa => pa.Name,
                opt => opt.MapFrom(pa => pa.Name))
                .ForMember(pa => pa.Department,
                opt => opt.MapFrom(pa => pa.Department));
        }
    }
}
