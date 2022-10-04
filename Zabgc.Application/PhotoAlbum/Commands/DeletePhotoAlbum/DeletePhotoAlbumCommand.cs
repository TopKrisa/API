using MediatR;
using System;

namespace Zabgc.Application.PhotoAlbum.Commands.DeletePhotoAlbum
{
    public class DeletePhotoAlbumCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
