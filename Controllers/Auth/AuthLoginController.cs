using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Server.Features.Auth.Init.Services;
using Notes.Server.Features.Auth.Login.Services;
using Notes.Server.Features.Auth.Logout.Services;
using Notes.Server.Features.Auth.Registration.Services;

namespace Notes.Server.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthLoginController
    {
        [HttpGet]
        [Authorize]
        [Route("init")]
        public async Task<IActionResult> Init([FromServices] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InitRequest(), cancellationToken);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationRequest request, [FromServices] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest request, [FromServices] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromServices] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new LogoutRequest(), cancellationToken);
            return result;
        }
    }
}
