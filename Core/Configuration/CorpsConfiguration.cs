namespace Notes.Server.Core.Configuration
{
    internal static class CorpsConfiguration
    {
        internal static IServiceCollection AddCorpsConfigurations(this IServiceCollection services)
        {
            services.AddCors(services =>
            {
                services.AddPolicy("Corps", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            return services;
        }
    }
}
