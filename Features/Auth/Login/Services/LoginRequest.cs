using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Server.Features.Auth.Login.Services
{
    public class LoginRequest : IRequest<IActionResult>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
