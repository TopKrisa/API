using System;
namespace Zabgc.Domain.Models
{
    public class News : BaseModel
    {

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public Guid NewsCategoryId { get; set; }
    }
}

