namespace Notes.Server.Core.Configuration
{
    internal static class MediatRConfiguration
    {
        internal static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            var assembly = typeof(Program).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
