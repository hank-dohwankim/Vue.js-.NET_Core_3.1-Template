using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Template.Data.Models;

namespace Template.Web.Dto
{
    public class PostDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsComplete { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
        public virtual IEnumerable<Tag> Tags { get; set; }
    }
}
