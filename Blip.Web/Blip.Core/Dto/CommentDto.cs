using System;

namespace Blip.Core.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
