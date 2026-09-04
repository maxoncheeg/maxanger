using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Users;

public class UserCredentials
{
    public long UserId { get; private set; }
    public string Password { get; private set; } = null!;

    public static UserCredentials Create(string passwordHash)
    {
        if (string.IsNullOrEmpty(passwordHash))
            throw new DomainException("INVALID_PASSWORD", "Password is required");

        return new UserCredentials { Password = passwordHash };
    }

    public void ChangePassword(string newPasswordHash, string oldPasswordHash)
    {
        if (string.IsNullOrEmpty(newPasswordHash) || string.IsNullOrEmpty(oldPasswordHash))
            throw new DomainException("INVALID_PASSWORD", "Password is required");
        
        if(newPasswordHash != oldPasswordHash)
            throw new DomainException("DIFFERENT_PASSWORDS", "Passwords don't match");
        
        Password = newPasswordHash;
    }

    public User User { get; private set; } = null!;
}