using Microsoft.IdentityModel.Tokens;
using Notes.Server.Core.Interfaces;
using Notes.Server.Infrastracture.Persistance.Models;
using Notes.Server.Properties;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Notes.Server.Core.Services
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateToken(Client client)
        {
            Claim[] claims = [new("user_id", client.Id.ToString())];

            var singingKey = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(EnvSettings.JwtSecret)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: EnvSettings.JwtIssuer,
                audience: EnvSettings.JwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(EnvSettings.JwtExpireMinute)),
                signingCredentials: singingKey);

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenHandler;
        }

        public void SetJwtTokenInCookie(HttpContext context, Client client)
        {
            var token = GenerateToken(client);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Path = "/",
                Expires = DateTime.UtcNow.AddDays(int.Parse(EnvSettings.JwtRefreshExpireDays))
            };

            context.Response.Cookies.Append("jwt", token, cookieOptions);


        }
    }
}
