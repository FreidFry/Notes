using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(Client client);
        void SetJwtTokenInCookie(HttpContext context, Client client);
        void RemoveJwtTokenInCookie(HttpContext context);
    }
}
