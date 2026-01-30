using ITI_API.DTO;
using ITI_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI_API.Controllers
{

    [Controller]
    [Route("[Controller]")]
    public class AccountControler(IAcountRepository repo) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO user)
        {
            var token = await repo.LoginAsync(user);
            return token is null ? Unauthorized() : Ok(token);
        }
        [HttpGet("get-all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var identity = User.Identity as ClaimsIdentity;
            return Ok("..");
        }
    }
}
