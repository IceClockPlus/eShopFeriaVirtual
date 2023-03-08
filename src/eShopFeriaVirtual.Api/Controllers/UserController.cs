using eShopFeriaVirtual.Application.Features.Users;
using eShopFeriaVirtual.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopFeriaVirtual.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<ActionResult> RegisterAsync(RegisterRequest request)
        {
            RegisterUserCommand registerUserCommand = new()
            {
                Email = request.Email,
                Name = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };
            var commandResult = await _mediator.Send(registerUserCommand);
            if (commandResult.Success) return Ok(commandResult.Data);
            return UnprocessableEntity(commandResult);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            LoginUserCommand loginUserCommand= new() { Email = request.Email, Password = request.Password };
            var commandResult = await _mediator.Send(loginUserCommand);
            if(commandResult is null) return Unauthorized();
            return Ok(commandResult);
        }

    }
}
