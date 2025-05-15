using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Server.Core.Interfaces;
using Notes.Server.Infrastracture.Persistance.DbContexts;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Features.Auth.Registration.Services
{
    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, IActionResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IValidator<RegistrationRequest> _validator;

        public RegistrationRequestHandler(AppDbContext appDbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IHttpContextAccessor contextAccessor, IValidator<RegistrationRequest> validator)
        {
            _dbContext = appDbContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _contextAccessor = contextAccessor;
            _validator = validator;

        }

        public async Task<IActionResult> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new BadRequestObjectResult(validationResult.Errors);

            var hashedPassword = _passwordHasher.HashPassword(request.Password);

            var client = new Client(request.UserName, request.Email, hashedPassword);

            await _dbContext.Clients.AddAsync(client, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            if (_contextAccessor.HttpContext == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);

            _jwtProvider.SetJwtTokenInCookie(_contextAccessor.HttpContext, client);

            return new OkObjectResult(client.Id);
        }
    }
}