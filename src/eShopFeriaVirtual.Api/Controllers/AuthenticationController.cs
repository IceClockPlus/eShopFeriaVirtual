using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eShopFeriaVirtual.Contracts.Authentication;
using eShopFeriaVirtual.Application.Services.Authentication;
using MediatR;

namespace eShopFeriaVirtual.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService, IMediator mediator)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
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
