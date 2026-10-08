namespace Maxanger.Application.Services.Security;

public interface ITokenService
{
    public string GenerateToken(long userId, string username);
    public string GenerateRefreshToken(long userId, string username);
    public Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken);
    public Task<long?> ExtractUserIdAsync(string token);
    public Task<bool> ValidateTokenAsync(string token);
}
