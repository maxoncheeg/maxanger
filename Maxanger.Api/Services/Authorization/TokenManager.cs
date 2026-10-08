namespace Maxanger.Api.Services.Authorization;

public class TokenManager(IHttpContextAccessor contextAccessor) : ITokenManager
{
    public string? RefreshToken { get; set; }

    public string? Token
    {
        get => ExtractToken();
        set;
    }

    private string? ExtractToken()
    {
        var context = contextAccessor.HttpContext;
        if (context == null) return null;

        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

        return !string.IsNullOrEmpty(authHeader) ? authHeader : null;
    }
}