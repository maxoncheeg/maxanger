using System.Security.Claims;
using Maxanger.Application.Services.Security.Abstract;

namespace Maxanger.Api.Services.Security;

public class SecurityService(IHttpContextAccessor httpContextAccessor) : ISecurityService
{
    public long? GetCurrentUserIdAsync()
    {
        return 2;
        if (httpContextAccessor.HttpContext == null) return null;
        
        var claimId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (long.TryParse(claimId, out var userId))
        {
            return userId;
        }

        return null;
    }
}