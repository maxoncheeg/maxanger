namespace Maxanger.Infrastructure.Entities;

public class UserCredentials
{
    public long UserId { get; set; }
    public string Password { get; set; }
    public User User { get; set; }
}