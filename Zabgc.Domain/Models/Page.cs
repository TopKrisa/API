using System;
namespace Zabgc.Domain.Models
{
    public class Page : BaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid PageCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}