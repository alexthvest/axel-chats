using System;
using Microsoft.AspNetCore.Mvc;

namespace AxelChats.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]")]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }
    }
}
