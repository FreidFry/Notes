using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Server.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Server.Infrastracture.Persistance.DbContexts;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Features.Auth.Login.Services
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, IActionResult>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IValidator<LoginRequest> _validator;

        public LoginRequestHandler(AppDbContext appDbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IHttpContextAccessor httpContextAccessor, IValidator<LoginRequest> validator)
        {
            _appDbContext = appDbContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _httpContextAccessor = httpContextAccessor;
            _validator = validator;
        }

        public async Task<IActionResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new BadRequestObjectResult(validationResult.Errors);

            var user = await _appDbContext.Clients.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            if (user == null)
                return new NotFoundObjectResult("User not found.");

            if (!_passwordHasher.VerifyHashedPassword(user.Password, request.Password))
                return new UnauthorizedObjectResult("Invalid password.");

            _jwtProvider.SetJwtTokenInCookie(_httpContextAccessor.HttpContext, user);

            return new OkObjectResult(new AuthResponceDTO { id = user.Id });
        }
    }
}
