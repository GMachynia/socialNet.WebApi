using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
    public class ConnectionController : ControllerBase
    {
        private readonly IHubContext<SocialNetHub> _hubContext;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IConnectionService _connectionService;

        public ConnectionController(ICommentService commentService, IHubContext<SocialNetHub> hubContext, IConnectionService connectionService, IUserService userService)
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

                var connection = await _connectionService.GetPostOwnerConnectionId(newComment.postId);
                await _hubContext.Clients.Client(connection).SendAsync("NewCommentNotification", newComment.postId);
                await _hubContext.Clients.Client(connection).SendAsync("UpdateComments", new UpdateCommentDto
                {
                    Content = updatedComment.Content,
                    Username = updatedComment.Username,
                    PostId = updatedComment.PostId
                });
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
