using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eShopFeriaVirtual.Contracts.Authentication;
using eShopFeriaVirtual.Application.Services.Authentication;

namespace eShopFeriaVirtual.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            return Ok(authResult);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = await _authenticationService.Login(
                request.Email,
                request.Password);
            return Ok(authResult);
        }
    }
}
