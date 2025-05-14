using MediatR;
using Notes.Server.Core.Interfaces;
using Notes.Server.Features.Auth.Init.DTOs;

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
            if(_HttpHepler.IsAuthenticated(_contextAccessor.HttpContext))
            {
                return Task.FromResult(new InitResponseDTO
                {
                    ClientId = _HttpHepler.GetUserId(_contextAccessor.HttpContext)
                });
            }

            return Task.FromResult(new InitResponseDTO
            {
                ClientId = null
            });
        }
    }
}
