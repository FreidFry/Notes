using System.Threading.RateLimiting;

namespace Notes.Server.Core.Configuration
{
    internal static class RateTimeConfigure
    {
        internal static IServiceCollection AddRateLimitConfiguration(this IServiceCollection services)
        {

            services.AddRateLimiter(options =>
            {
                options.AddPolicy("Global", httpContext =>
                    RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 80,
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 2,
                            Window = TimeSpan.FromMinutes(1),
                            SegmentsPerWindow = 6,
                        })
                );

                options.AddPolicy("Auth", httpContext =>
                    RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 5,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(15),
                            SegmentsPerWindow = 3,
                        })
                );
            });
            return services;
        }
    }
}
