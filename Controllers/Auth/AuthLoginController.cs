using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Server.Features.Auth.Init.Services;
using Notes.Server.Features.Auth.Registration.Services;

namespace Notes.Server.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthLoginController
    {
        [HttpGet]
        [Route("init")]
        [AllowAnonymous]
        public async Task<IActionResult> Init([FromQuery] InitRequest request, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request, HttpClient httpClient, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return result;
        }
    }
}
