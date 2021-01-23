using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AxelChats.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult User()
        {
            var nameClaim = HttpContext.User.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType);
            var emailClaim = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email);

            return Ok(new
            {
                Name = nameClaim.Value,
                Email = emailClaim.Value
            });
        }
    }
}
