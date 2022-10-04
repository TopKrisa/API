using AutoMapper;
using System;
using System.Collections.Generic;
using Zabgc.Application.Common.Mappings;

namespace Zabgc.Application.PhotoAlbum.Queries.GetPhotoAlbumList
{
    public class PhotoAlbumLookupDto : IMapWith<Domain.Models.PhotoAlbum>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Domain.Models.Photo> Photos { get; set; }
        public Domain.Models.Department Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.PhotoAlbum, PhotoAlbumLookupDto>()
                .ForMember(pa => pa.Name,
                opt => opt.MapFrom(pa => pa.Name))
                .ForMember(pa => pa.Photos,
                opt => opt.MapFrom(pa => pa.Photos))
                .ForMember(pa => pa.Department,
                opt => opt.MapFrom(pa => pa.Department));
        }
    }
}
