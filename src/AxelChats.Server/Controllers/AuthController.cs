using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AxelChats.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, "alexthvest")
            };

            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Auth:SecretKey"])), SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: identity.Claims,
                expires: DateTime.Now.AddMinutes(15),// TODO: Change to Configuration Auth:LifeTime
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return Ok(token);
        }

        [HttpPost("[action]")]
        public IActionResult Authorize()
        {
            throw new NotImplementedException();
        }
    }
}
