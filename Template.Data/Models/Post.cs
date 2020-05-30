using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Data.Models
{
    public class Post
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