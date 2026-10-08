using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Maxanger.Application.Services.Security;

public class JwtOptions
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SigningKey { get; init; }
    public int ExpirationSeconds { get; init; }
    public int RefreshExpirationSeconds { get; init; }
    public string TokenAlgorithm { get; init; }
    public string RefreshTokenAlgorithm { get; init; }

    public TimeSpan ClockSkew { get; set; } = TimeSpan.FromSeconds(5);

    public SymmetricSecurityKey SymmetricSecurityKey =>
        new(Encoding.ASCII.GetBytes(SigningKey));
}