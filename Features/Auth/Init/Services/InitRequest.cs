using MediatR;
using Notes.Server.Features.Auth.Init.DTOs;

namespace Notes.Server.Features.Auth.Init.Services
{
    public class InitRequest : IRequest<InitResponseDTO>
    {}
}
