using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using socialNet.Dtos.RequestDtos;
using socialNet.Services.Interfaces;
using socialNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace socialNet.WebApi.Controllers.Post
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IStringLocalizer<PostController> _localizer;
        private readonly IHubContext<SocialNetHub> _hubContext;
        private readonly IConnectionService _connectionService;
        private readonly INotificationService _notificationService;

        public PostController(IPostService postService, IStringLocalizer<PostController> localizer, IHubContext<SocialNetHub> hubContext, IConnectionService connectionService, INotificationService notificationService)
        {
            _postService = postService;
            _localizer = localizer;
            _hubContext = hubContext;
            _connectionService = connectionService;
            _notificationService = notificationService;
        }

        [HttpPost("addPostImage"), DisableRequestSizeLimit]
        public async Task<IActionResult> AddPostWithImage()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.GetFile("image");
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid() + "-" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    
                    return Ok(new { FileName = fileName, DbPath = dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost("addPostDescription")]
        public async Task<IActionResult> AddPostDescription(NewPostRequestDto newPost)
        {
            try
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var post = await _postService.AddNewPost(newPost, userId);
                await _notificationService.AddNewPostNotification(userId);
                var connections = await _connectionService.GetFriendsConnectionId(userId);
                var postJson = JsonConvert.SerializeObject(new {
                    postContent = post.PostContent,
                    postId = post.PostId, 
                    username = post.PostOwner.Username,
                    postImage = post.PostImage,
                    profilePicture = post.PostOwner.ProfilePicture
                });
                await _hubContext.Clients.Clients(connections).SendAsync("NewPostNotification", postJson);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getPosts")]
        public async Task<IActionResult> GetPosts(int page, int pageSize)
        {
            try
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var posts = await _postService.GetPosts(page, pageSize, userId);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
