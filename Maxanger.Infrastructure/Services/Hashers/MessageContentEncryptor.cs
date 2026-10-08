using System.Security.Cryptography;
using System.Text;
using Maxanger.Domain.Abstractions.Hashers;

namespace Maxanger.Infrastructure.Services.Hashers;

public class MessageContentEncryptor : IMessageContentEncryptor
{
    private readonly byte[] _key;

    public MessageContentEncryptor(string base64Key)
    {
        _key = Convert.FromBase64String(base64Key);
        
        if (_key.Length != 32)
            throw new ArgumentException("Key must be 32 bytes (AES-256)");
    }
    
    public static string GenerateNewKey()
    {
        var key = new byte[32];
        RandomNumberGenerator.Fill(key);
        return Convert.ToBase64String(key);
    }
    
    public string Encrypt(string plainText)
    {
        var plaintextBytes = Encoding.UTF8.GetBytes(plainText);
        var nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
        RandomNumberGenerator.Fill(nonce);
        
        var ciphertext = new byte[plaintextBytes.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize];

        using var aes = new AesGcm(_key, AesGcm.TagByteSizes.MaxSize);
        aes.Encrypt(nonce, plaintextBytes, ciphertext, tag);
        
        var result = new byte[nonce.Length + tag.Length + ciphertext.Length];
        Buffer.BlockCopy(nonce, 0, result, 0, nonce.Length);
        Buffer.BlockCopy(tag, 0, result, nonce.Length, tag.Length);
        Buffer.BlockCopy(ciphertext, 0, result, nonce.Length + tag.Length, ciphertext.Length);

        return Convert.ToBase64String(result);
    }

    public string Decrypt(string encryptedText)
    {
        var fullBytes = Convert.FromBase64String(encryptedText);
        var nonce = fullBytes[..AesGcm.NonceByteSizes.MaxSize];
        var tag = fullBytes[AesGcm.NonceByteSizes.MaxSize..(AesGcm.NonceByteSizes.MaxSize + AesGcm.TagByteSizes.MaxSize)];
        var ciphertext = fullBytes[(AesGcm.NonceByteSizes.MaxSize + AesGcm.TagByteSizes.MaxSize)..];

        var plaintextBytes = new byte[ciphertext.Length];
        using var aes = new AesGcm(_key, AesGcm.TagByteSizes.MaxSize);
        aes.Decrypt(nonce, ciphertext, tag, plaintextBytes);

        return Encoding.UTF8.GetString(plaintextBytes);
    }
}