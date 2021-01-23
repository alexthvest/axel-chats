using System;
using System.Security.Claims;
using AxelChats.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AxelChats.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtFactory _jwtFactory;

        public AuthController(IJwtFactory jwtFactory)
        {
            _jwtFactory = jwtFactory;
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate([FromBody]string name)
        {
            var token = _jwtFactory.GenerateAccessToken(new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(ClaimTypes.Email, $"{name}@gmail.com")
            });
            
            return Ok(new
            {
                Token = token,
                RefreshToken = ""
            });
        }

        [HttpPost("[action]")]
        public IActionResult Authorize()
        {
            throw new NotImplementedException();
        }
    }
}
