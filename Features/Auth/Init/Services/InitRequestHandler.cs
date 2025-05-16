using MediatR;
using Notes.Server.Core.Interfaces;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Features.Auth.Init.Services
{
    public class InitRequestHandler : IRequestHandler<InitRequest, AuthResponceDTO>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpContextHelper _HttpHepler;

        public InitRequestHandler(IHttpContextAccessor contextAccessor, IHttpContextHelper httpContextHelper)
        {
            _contextAccessor = contextAccessor;
            _HttpHepler = httpContextHelper;
        }

        public async Task<AuthResponceDTO> Handle(InitRequest request, CancellationToken cancellationToken)
        {
            var user = _contextAccessor.HttpContext?.User;
            var userId = _HttpHepler.GetUserId(_contextAccessor.HttpContext);

            return new AuthResponceDTO { id = userId };
        }
    }
}
