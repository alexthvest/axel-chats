using System.Linq;
using AxelChats.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AxelChats.Server.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult GetValues()
        {
            var users = _userManager.Users.ToList();
            
            return Ok(users);
        }
    }
}
