using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Template.Data.Models;
using Template.Services.Repository.IRepository;
using Template.Web.ViewModels;

namespace Template.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IAppUserRepository _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReplyController(ILogger<PostController> logger, IPostRepository postRepository, IAppUserRepository userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _postRepository = postRepository;
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("/api/post/{postId:int}/reply", Name = "AddReply")]
        [AllowAnonymous]
        public async Task<IActionResult> AddReply(ReplyViewModel model, int postId)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user, postId);

            _postRepository.AddReply(reply);
            //await _userService.UpdateUserRating(userId, typeof(PostReply));

            return RedirectToAction("GetPosts", "Post", new { id = postId });
        }

        private PostReply BuildReply(ReplyViewModel model, ApplicationUser user, int postId)
        {
            var post = _postRepository.GetPostById(postId);
            return new PostReply
            {
                Post = post,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                User = user
            };
        }
    }
}