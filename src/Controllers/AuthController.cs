using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.DTOs.AuthDTO;
using src.Interfaces;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInfoDTO userInfo)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var appUser = new AppUser
                {
                    UserName = userInfo.Username
                };

                var createUser = await _userManager.CreateAsync(appUser, userInfo.Password);
                if(createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded)
                    {
                        return Ok(new UserInfoResponseDTO 
                        {
                            Username = appUser.UserName,
                            Token = _tokenService.GenerateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, $"Failed to create user: {roleResult.Errors}");
                    }
                }
                else
                {
                    return StatusCode(500, $"Failed to create user: {string.Join("; ", createUser.Errors.Select(e => e.Description))}");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Failed to create user: {e}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserInfoDTO userInfoDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userInfoDTO.Username);
            if(user == null)
            {
                return Unauthorized("Username or password is invalid");
            }

            var passCheck = await _signinManager.CheckPasswordSignInAsync(user, userInfoDTO.Password, false);
            if(!passCheck.Succeeded)
            {
                return Unauthorized("Username or password is invalid");
            }

            return Ok(new UserInfoResponseDTO
            {
                Username = user.UserName,
                Token = _tokenService.GenerateToken(user)
            });
        }
    }
}