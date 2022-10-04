using AutoMapper;
using System;
using System.Collections.Generic;
using Zabgc.Application.Common.Mappings;
using Zabgc.Application.PhotoAlbum.Commands.UpdatePhotoAlbum;
using Zabgc.Domain.Models;

namespace Zabgc.WebApi.Models.PhotoAlbum
{
    public class UpdatePhotoAlbumDto : IMapWith<UpdatePhotoAlbumCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Domain.Models.Department Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePhotoAlbumDto, UpdatePhotoAlbumCommand>()
                .ForMember(pa => pa.Id,
                opt => opt.MapFrom(pa => pa.Id))
                .ForMember(pa => pa.Name,
                opt => opt.MapFrom(pa => pa.Name))
                .ForMember(pa => pa.Department,
                opt => opt.MapFrom(pa => pa.Department))
                .ForMember(pa => pa.Photos,
                opt => opt.MapFrom(pa => pa.Photos));
        }
    }
}
