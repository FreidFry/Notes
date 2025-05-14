using Notes.Server.Core.Interfaces;
using System.Security.Claims;

namespace Notes.Server.Core.Services
{
    public class HttpContextHelper : IHttpContextHelper
    {
        public Guid? GetUserId(HttpContext httpContext)
        {
            var uid = httpContext.User.FindFirstValue("user_id");
            if (string.IsNullOrEmpty(uid) || !Guid.TryParse(uid, out Guid guid))
                return null;

            return guid;
        }

        public bool IsOwner(HttpContext httpContext, Guid resourceOwnerId)
        {
            var userId = GetUserId(httpContext);
            return userId != null && userId == resourceOwnerId;
        }

        public bool HasPermission(HttpContext httpContext, Guid resourceOwnerId, bool isPublic) => isPublic ? true : IsOwner(httpContext, resourceOwnerId);

        public bool IsAuthenticated(HttpContext httpContext) => httpContext.User.Identity?.IsAuthenticated == true;
    }
}
