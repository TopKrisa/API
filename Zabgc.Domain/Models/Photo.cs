using System;
namespace Zabgc.Domain.Models
{
    public class Photo : BaseModel
    {
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public double Size { get; set; }
    }
}
