using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Server.Core.Interfaces;

namespace Notes.Server.Features.Auth.Logout.Services
{
    public class LogoutRequestHandler : IRequestHandler<LogoutRequest, IActionResult>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtProvider _JwtProvider;

        public LogoutRequestHandler(IHttpContextAccessor contextAccessor, IJwtProvider jwtProvider)
        {
            _contextAccessor = contextAccessor;
            _JwtProvider = jwtProvider;
        }

        public Task<IActionResult> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            var httpContext = _contextAccessor.HttpContext;
            if (httpContext == null)
            {
                return Task.FromResult<IActionResult>(new BadRequestObjectResult("HttpContext is null."));
            }

            _JwtProvider.RemoveJwtTokenInCookie(httpContext);
            return Task.FromResult<IActionResult>(new OkObjectResult(true));
        }
    }
}
