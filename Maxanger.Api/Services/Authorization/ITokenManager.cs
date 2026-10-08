namespace Maxanger.Api.Services.Authorization;

public interface ITokenManager
{    
    public string? RefreshToken { get; set; }
    public string? Token { get; set; }
}