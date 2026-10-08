using Maxanger.Infrastructure.Services.Hashers;

namespace Maxanger.Infrastructure.Tests.Services;

public class MessageContentEncryptorTests
{
    [Theory]
    [InlineData("/yaBzJGJAdkvzPsmZihFbmaeEEJnSVZUXkeotVf9rKU=", "aboba")]
    [InlineData("OwVe/lP82KXZNwC3W0Wkof2kxalUcXKafvq7COJeJTE=", "terrific drugs to treat disease")]
    public void EncryptAndDecrypt_Code_ReturnsLine(string key, string message)
    {
        var encryptor = new MessageContentEncryptor(key);
        
        var encrypted = encryptor.Encrypt(message);
        var decrypted = encryptor.Decrypt(encrypted);
        
        Assert.Equal(message, decrypted);
    }
}