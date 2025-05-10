namespace Notes.Server.Properties
{
    internal class JwtOptions
    {
        public string? JwtSecret { get; set; }
        public string? JwtIssuer { get; set; }
        public string? JwtAudience { get; set; }
        public string? JwtExpireTime { get; set; }
        public string? JwtRefreshExpireTime { get; set; }
    }
}
