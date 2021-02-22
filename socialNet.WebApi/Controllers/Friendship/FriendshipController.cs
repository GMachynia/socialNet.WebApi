using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using socialNet.Dtos.RequestDtos;
using socialNet.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace socialNet.WebApi.Controllers.Friendship
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IStringLocalizer<FriendshipController> _localizer;

        public FriendshipController(IFriendshipService friendshipService, IStringLocalizer<FriendshipController> localizer)
        {
            _friendshipService = friendshipService;
            _localizer = localizer;
        }

        [HttpPost("addFriend")]
        public async Task<IActionResult> AddFriend(FriendshipRequestDto friendshipRequestDto)
        {

            try
            {
                await _friendshipService.AddUserToFriends(friendshipRequestDto.Username, friendshipRequestDto.FriendUsername);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("isFriend")]
        public async Task<IActionResult> IsFriend(string username, string friendUsername)
        {
            try
            {
                var isFriend = await _friendshipService.IsFriend(username, friendUsername);
                return Ok(isFriend);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("updateFriendship")]
        public async Task<IActionResult> updateFriendshipStatus(UpdateFriendshipStatusRequestDto updateFriendshipStatusRequestDto)
        {
            try
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                await _friendshipService.UpdateFriendshipStatus(userId, updateFriendshipStatusRequestDto);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
