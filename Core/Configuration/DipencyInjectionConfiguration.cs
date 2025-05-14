using FluentValidation;
using Notes.Server.Core.Interfaces;
using Notes.Server.Core.Services;
using Notes.Server.Features.Auth.Registration.Services;
using Notes.Server.Features.Auth.Registration.Validations;

namespace Notes.Server.Core.Configuration
{
    public static class DipencyInjectionConfiguration
    {
        public static IServiceCollection AddDipencyInjectionConfiguration(this IServiceCollection services) {

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IHttpContextHelper, HttpContextHelper>();

            services.AddScoped<IValidator<RegistrationRequest>, RegistrationValidator>();


            return services;
        }
    }
}
