using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Maxanger.Application.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Maxanger.Infrastructure.Services.Security;

public class JwtTokenService(IOptions<JwtOptions> options) : ITokenService
{
    private readonly JwtOptions _options = options.Value;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public string GenerateToken(long userId, string username)
    {
        var expiration = TimeSpan.FromSeconds(_options.ExpirationSeconds);
        var claims = ConfigureClaims(userId, username);
        var token = GenerateToken(_options.TokenAlgorithm, expiration, claims);

        return token;
    }

    public string GenerateRefreshToken(long userId, string username)
    {
        var expiration = TimeSpan.FromSeconds(_options.RefreshExpirationSeconds);
        var claims = ConfigureClaims(userId, username);
        var token = GenerateToken(_options.RefreshTokenAlgorithm, expiration, claims);

        return token;
    }

    public async Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken)
    {
        var refreshResult = await GetValidationResultAsync(refreshToken);
        var expiredResult = _tokenHandler.ReadJwtToken(expiredToken);

        if (!refreshResult.IsValid || expiredResult == null) return null;

        var expiration = TimeSpan.FromSeconds(_options.ExpirationSeconds);

        if (!refreshResult.Claims.TryGetValue(Claims.Identifier, out var id))
            return null;

        string? normalId = id.ToString(),
            expiredNormalId = expiredResult.Claims.FirstOrDefault(c => c.Type == Claims.Identifier)?.Value
                .ToString();

        if (normalId == null || expiredNormalId == null) return null;

        return normalId != expiredNormalId
            ? null
            : GenerateToken(_options.TokenAlgorithm, expiration, expiredResult.Claims);
    }

    public async Task<long?> ExtractUserIdAsync(string token)
    {
        var result = await GetValidationResultAsync(token);

        if (!result.IsValid)
            return null;

        if (!result.Claims.TryGetValue(Claims.Identifier, out var claimId)
            || !long.TryParse(claimId.ToString(), out var id))
            return null;

        return id;
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        var result = await GetValidationResultAsync(token);

        return result.IsValid;
    }

    private async Task<TokenValidationResult> GetValidationResultAsync(string token)
    {
        var result = await _tokenHandler.ValidateTokenAsync(token, GetParameters());

        return result;
    }

    private IList<Claim> ConfigureClaims(long userId, string username)
    {
        var claims = new List<Claim>
        {
            new(Claims.Identifier, userId.ToString()),
            new(Claims.Username, username.ToString()),
        };

        // claims.AddRange(user.Roles.Select(role => new Claim(Claims.Role, role.Type.ToString())));

        return claims;
    }

    private string GenerateToken(string algorithm, TimeSpan expiration, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(expiration),
            signingCredentials: new SigningCredentials(_options.SymmetricSecurityKey, algorithm));

        var rawToken = _tokenHandler.WriteToken(token);

        return rawToken;
    }

    private TokenValidationParameters GetParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience,
            ClockSkew = _options.ClockSkew,
            IssuerSigningKey = _options.SymmetricSecurityKey
        };
    }
}