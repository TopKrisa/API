using System;

namespace Zabgc.Domain.Models
{
    public class Question : BaseModel
    {
        public string Message { get; set; }
        public string User { get; set; } 
        public bool Activity { get; set; }
        public string? Answer { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string? AdminName { get; set; } 
    }

}