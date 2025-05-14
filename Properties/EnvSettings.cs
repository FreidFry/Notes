using dotenv.net;

namespace Notes.Server.Properties
{
    public static class EnvSettings
    {
        public static string ConnectionString => Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new Exception("\"CONNECTION_STRING\" not found");
        public static string JwtSecret => Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new Exception("\"JWT_SECRET\" not found");
        public static string JwtIssuer => Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new Exception("\"JWT_ISSUER\" not found");
        public static string JwtAudience => Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new Exception("\"JWT_AUDIENCE\" not found");
        public static string JwtExpireMinute => Environment.GetEnvironmentVariable("JWT_EXPIRE_TIME_MINUTE") ?? throw new Exception("\"JWT_EXPIRE_TIME_MINUTE\" not found");
        public static string JwtRefreshExpireDays => Environment.GetEnvironmentVariable("JWT_REFRESH_EXPIRE_TIME_DAYS") ?? throw new Exception("\"JWT_REFRESH_EXPIRE_TIME_DAYS\" not found");
    }
}
