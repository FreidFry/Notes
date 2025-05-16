using MediatR;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Features.Auth.Init.Services
{
    public class InitRequest : IRequest<AuthResponceDTO>
    {}
}
