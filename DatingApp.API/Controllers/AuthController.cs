using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Data;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        public AuthController(DataContext dbContext, ITokenService tokenService, IAuthService authService)
        {
            this._context = dbContext;
            this._tokenService = tokenService;
            this._authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                return Ok(_authService.Register(registerUserDto));
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            try
            {
                return Ok(_authService.Login(authUserDto));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.User.ToList());
        }
    }
}