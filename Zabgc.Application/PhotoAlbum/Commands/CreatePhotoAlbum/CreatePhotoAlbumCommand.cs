using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabgc.Domain.Models;

namespace Zabgc.Application.PhotoAlbum.Commands.CreatePhotoAlbum
{
    public class CreatePhotoAlbumCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Domain.Models.Department Department { get; set; }
    }
}
