using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Server.Features.Auth.Logout.Services
{
    public class LogoutRequest : IRequest<IActionResult>
    {}
}
