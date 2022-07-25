using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eShopFeriaVirtual.Contracts.Authentication;

namespace eShopFeriaVirtual.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [Route("register")]
        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}
