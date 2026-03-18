using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Application.Services.Security.Abstract;

public interface ITokenService
{
    public string GenerateToken(IUser user);
    public Task<string?> ValidateTokenAsync(string token);
}