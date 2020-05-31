using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Models;

namespace Template.Services.Services.IServices
{
    public interface IPostService
    {
        //int GetReplyCount(int id);
        //bool PostExists(string title);
        //bool PostExists(int id);
        ////bool CreatePost(Post post);
        //bool UpdatePost(Post post);
        //bool DeletePost(Post post);

        Post GetPostById(int postId);
        
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetPostsByCategory(int categId);
        IEnumerable<Post> GetPostsByUserId(string userId);
        IEnumerable<Post> GetLatestPosts(int categoryId);
        IEnumerable<Post> GetFilteredPosts(Category category, string searchQuery);

        ServiceResponse<Post> CreatePost(Post post);
        ServiceResponse<Post> UpdatePost(Post post);
        ServiceResponse<Post> DeletePost(Post post);
        ServiceResponse<PostReply> AddReply(PostReply reply);
        ServiceResponse<PostReply> EditReply(PostReply reply);
        ServiceResponse<PostReply> DeleteReply(PostReply reply);
    }
}
