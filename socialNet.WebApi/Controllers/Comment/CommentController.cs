using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using socialNet.Dtos;
using socialNet.Dtos.RequestDtos;
using socialNet.Services.Interfaces;
using socialNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Controllers.Comment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentController : ControllerBase
    {
        private readonly IHubContext<SocialNetHub> _hubContext;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IConnectionService _connectionService;

        public CommentController(ICommentService commentService, IHubContext<SocialNetHub> hubContext, IConnectionService connectionService, IUserService userService)
        {
            _commentService = commentService;
            _hubContext = hubContext;
            _connectionService = connectionService;
            _userService = userService;
        }


        [HttpPost("addComment")]
        public async Task<IActionResult> AddNewComment(NewCommentRequestDto newComment)
        {
            try
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var comment = new CommentDto
                {
                    CommentOwnerId = userId,
                    Content = newComment.content,
                    PostId = newComment.postId
                };
                var updatedComment = await _commentService.AddComment(comment);
                var connections = await _connectionService.GetPostOwnerConnectionIds(newComment.postId);
                var commentJson = JsonConvert.SerializeObject(new
                 {
                     content = updatedComment.Content,
                     commentOwner = updatedComment.Username,
                     postId = updatedComment.PostId
                 });
                await _hubContext.Clients.Clients(connections).SendAsync("NewCommentNotification", commentJson);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
