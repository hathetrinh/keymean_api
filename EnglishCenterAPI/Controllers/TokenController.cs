using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EnglishCenterAPI.Common;
using EnglishCenterAPI.Models;
using EnglishCenterAPI.Repository;

namespace EnglishCenterAPI.Controllers
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        //private UserRepository _userRepository;

        //public TokenController(UserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        private readonly englishcenterContext _context;
        private IConfiguration _config;
        private IUnitOfWork _unitOfWork;
        private UserRepository _userRepository;

        public TokenController(englishcenterContext context, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _context = context;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        //[HttpGet("test")]
        //public async Task<IActionResult> Index()
        //{
        //    return Ok(BuildToken());
        //}

        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] LoginModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Invalid credentials");
            var _passwordHashed = MD5Helper.Encode(user.Password);
            var _user = _context.User.FirstOrDefault(x => x.Email == user.Email && x.Password == _passwordHashed);
            if (_user == null)
                return BadRequest("Invalid credentials");

            return Ok(new { token = BuildToken(_user) });
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddSeconds(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("Test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok("200");
        }
    }
}