using System;
using Microsoft.AspNetCore.Mvc;

namespace AxelChats.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetAccountById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
