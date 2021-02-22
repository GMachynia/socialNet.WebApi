using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using socialNet.Data;
using socialNet.Dtos.RequestDtos;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace socialNet.WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<UserController> _localizer;

        public UserController(IUserService userService, IConfiguration Configuration, IStringLocalizer<UserController> localizer)
        {
            _userService = userService;
            _configuration = Configuration;
            _localizer = localizer;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestDto model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { error = _localizer["IncorrectUserOrPassword"].Value });

            var tokenHandler = new JwtSecurityTokenHandler();
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.UserId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpRequestDto model)
        {

            try
            {
                var user = await _userService.Create(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = _localizer[ex.Message].Value });
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequestDto model)
        {
            try
            {
                await _userService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = _localizer[ex.Message].Value });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("getUsersByUsernameString")]
        public async Task<IActionResult> GetByUsernameString(string usernameString)
        {
            try
            {
                var users = await _userService.GetUsersByStringAsync(usernameString);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [HttpGet("getAllUsersByUsernameString")]
        public async Task<IActionResult> GetAllByUsernameString(string usernameString)
        {
            try
            {
                var users = await _userService.GetAllUsersByStringAsync(usernameString);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getUserProfile")]
        public async Task<IActionResult> GetUserProfile(string username)
        {
            try
            {
                var user = await _userService.GetUserProfileAsync(username);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpGet("getMyProfile")]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                var userId = int.Parse(HttpContext.User.Identity.Name);
                var userProfile = await _userService.GetMyProfileAsync(userId);
                return Ok(userProfile);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }          
        }

    }
}