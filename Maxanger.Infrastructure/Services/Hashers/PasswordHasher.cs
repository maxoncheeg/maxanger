using System.Security.Cryptography;
using Maxanger.Domain.Abstractions.Hashers;

namespace Maxanger.Infrastructure.Services.Hashers;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return password + "♂♀";
    }

    public bool Verify(string hashedPassword, string password)
    {
        return hashedPassword[..^2].Equals(password);
    }
}