using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Notes.Server.Properties;
using System.Text;

namespace Notes.Server.Core.Configuration
{
    internal static class JWTConfiguration
    {
        internal static IServiceCollection AddJwtConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var token = context.HttpContext.Request.Cookies["jwt"];
                            if (!string.IsNullOrEmpty(token))
                                context.Token = token;
                            return Task.CompletedTask;
                        }
                    };

                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvSettings.JwtSecret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidIssuer = EnvSettings.JwtIssuer,
                        ValidAudience = EnvSettings.JwtAudience,
                        ValidateLifetime = true,
                    };
                });

            services.Configure<JwtOptions>(options =>
            {
                options.JwtSecret = EnvSettings.JwtSecret;
                options.JwtIssuer = EnvSettings.JwtIssuer;
                options.JwtAudience = EnvSettings.JwtAudience;
                options.JwtExpireTime = EnvSettings.JwtExpireMinute;
                options.JwtRefreshExpireTime = EnvSettings.JwtRefreshExpireDays;
            });

            services.AddAuthorization();

            return services;
        }
    }
}
