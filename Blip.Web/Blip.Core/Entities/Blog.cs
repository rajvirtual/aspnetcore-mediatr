using System;
using System.Collections.Generic;
using System.Text;

namespace Blip.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
