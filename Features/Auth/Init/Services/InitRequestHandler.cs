using MediatR;
using Notes.Server.Core.Interfaces;
using Notes.Server.Features.Auth.Init.DTOs;
using System.Security.Claims;

namespace Notes.Server.Features.Auth.Init.Services
{
    public class InitRequestHandler : IRequestHandler<InitRequest, InitResponseDTO>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpContextHelper _HttpHepler;

        public InitRequestHandler(IHttpContextAccessor contextAccessor, IHttpContextHelper httpContextHelper)
        {
            _contextAccessor = contextAccessor;
            _HttpHepler = httpContextHelper;
        }

        public Task<InitResponseDTO> Handle(InitRequest request, CancellationToken cancellationToken)
        {
            var user = _contextAccessor.HttpContext?.User;
            var userId = user?.FindFirstValue("user_id");

            return Task.FromResult(new InitResponseDTO
            {
                ClientId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId)
            });
        }
    }
}
