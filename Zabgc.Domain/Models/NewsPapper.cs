using System;
namespace Zabgc.Domain.Models
{
    public class Newspapper : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}

