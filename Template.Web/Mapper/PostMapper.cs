using AutoMapper;
using System;
using System.Collections.Generic;
using Template.Data.Models;
using Template.Web.Dto;

namespace Template.Web.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostDto>().ReverseMap();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsProcess { get; set; }
        public bool IsComplete { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
        public virtual IEnumerable<Tag> Tags { get; set; }
    }
}
