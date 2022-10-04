using System;
using System.Collections.Generic;

namespace Zabgc.Domain.Models
{
    public class Comment : BaseModel
    {
        public Guid? UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
        public Comment? Answer { get; set; }

    }
}

