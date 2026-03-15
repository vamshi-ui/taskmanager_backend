
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaskManager_Backend.DTOS;
using TaskManager_Backend.Interfaces;
using TaskManager_Backend.Models;

namespace TaskManager_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authrepo;
        private readonly IJwtService _jwtservice;
        public AuthController(IAuthRepository authRepo, IJwtService jwtservice)
        {
            _authrepo = authRepo;
            _jwtservice = jwtservice;
        }

        /// <summary>
        /// method for registering user details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        #region Register Api
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest user)
        {
            bool isUserSaved = await _authrepo.Register(user);
            if (isUserSaved)
            {
                return Ok(new
                {
                    success = "true",
                    message = "user registered successfully"
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = "false",
                    message = "something went wrong"
                });
            }
        }
        #endregion

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var userDetails = await _authrepo.Login(req);
            if (userDetails != null)
            {
        //         HttpContext.Response.Cookies.Append("user-cookie", JsonSerializer.Serialize(new User()
        //         {
        //             Email = userDetails.Email,
        //             UserName = userDetails.UserName,
        //             RoleId = userDetails.RoleId
        //         }),
        // new CookieOptions
        // {
        //     HttpOnly = true,
        //     Secure = true,
        //     SameSite = SameSiteMode.Strict
        // });
        var token = _jwtservice.GenerateToken(userDetails);
                return Ok(new
                {
                    success = true,
                    message = "login success",
                    token
                });
            }

            return Unauthorized(new
            {
                success = false,
                message = "invalid credentials"
            });
        }
    }

}