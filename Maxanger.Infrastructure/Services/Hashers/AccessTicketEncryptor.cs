using System.Security.Cryptography;
using System.Text;
using Maxanger.Domain.Abstractions.Hashers;

namespace Maxanger.Infrastructure.Services.Hashers;

public class AccessTicketEncryptor : IAccessTicketEncryptor
{
    private readonly byte[] _key;
    
    public AccessTicketEncryptor(string secretKey)
    {
        using var sha = SHA256.Create();
        _key = sha.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
    }

    public string Encrypt(string code)
    {
        byte[] data = Encoding.UTF8.GetBytes(code);
        byte[] result = new byte[data.Length];
        
        for (int i = 0; i < data.Length; i++)
            result[i] = (byte)(data[i] ^ _key[i % _key.Length]);
        
        return Convert.ToBase64String(result);
    }

    public string Decrypt(string code)
    {
        byte[] data = Convert.FromBase64String(code);
        byte[] result = new byte[data.Length];
        
        for (int i = 0; i < data.Length; i++)
            result[i] = (byte)(data[i] ^ _key[i % _key.Length]);
        
        return Encoding.UTF8.GetString(result);
    }
}