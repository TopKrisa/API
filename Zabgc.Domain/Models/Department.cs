using System;

namespace Zabgc.Domain.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime? EditionDate { get; set; }

    }
}