using MediatR;
using System;
using System.Collections.Generic;
using Zabgc.Domain.Models;

namespace Zabgc.Application.PhotoAlbum.Commands.UpdatePhotoAlbum
{
    public class UpdatePhotoAlbumCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Domain.Models.Department Department { get; set; }
    }
}
