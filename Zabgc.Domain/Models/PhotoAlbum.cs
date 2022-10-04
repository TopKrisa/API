using System.Collections.Generic;

namespace Zabgc.Domain.Models
{
    public class PhotoAlbum : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Department Department { get; set; }
    }
}
