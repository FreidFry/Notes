namespace Notes.Server.Core.Configuration
{
    static internal class CorpsConfiguration
    {
        static internal IServiceCollection AddCorpsConfigurations(this IServiceCollection services)
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
