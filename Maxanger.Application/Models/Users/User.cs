using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Application.Models.Users;

public class User : IUser
{
    public long Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}