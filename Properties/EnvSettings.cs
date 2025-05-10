using dotenv.net;

namespace Notes.Server.Properties
{
    public static class EnvSettings
    {
        public static string? ConnectionString => Environment.GetEnvironmentVariable("CONNECTION_STRING");
        public static string? JwtSecret => Environment.GetEnvironmentVariable("JWT_SECRET");
        public static string? JwtIssuer => Environment.GetEnvironmentVariable("JWT_ISSUER");
        public static string? JwtAudience => Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        public static string? JwtExpireTime => Environment.GetEnvironmentVariable("JWT_EXPIRE_TIME");
        public static string? JwtRefreshExpireTime => Environment.GetEnvironmentVariable("JWT_REFRESH_EXPIRE_TIME");
    }
}
