using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Server.Features.Auth.Registration.Services
{
    public class RegistrationRequest : IRequest<IActionResult>
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }

    }
}