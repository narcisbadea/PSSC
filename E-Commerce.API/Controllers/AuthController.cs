﻿using E_Commerce.BLL.DTOs;
using E_Commerce.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace E_Comerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> SignUp(RegisterDTO auth)
        {
            var result = await _authService.SignUp(auth);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO request)
        {
            if (!await _authService.CheckPassword(request))
            {
                return BadRequest(new { Message = "Invalid password or user not found!" });
            }
            var token = await _authService.GenerateToken(request, request.rememberMe);
            return Ok(new { token = (new JwtSecurityTokenHandler().WriteToken(token)).ToString() });
        }

        [Authorize]
        [HttpGet("logged-username")]
        public ActionResult<string> GetUserName()
        {
            var result = _authService.GetLoggedUserName();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
