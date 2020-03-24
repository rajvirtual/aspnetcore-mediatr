using System;
using System.Collections.Generic;

namespace Blip.Core.Dto
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Author { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
