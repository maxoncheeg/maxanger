using Maxanger.Infrastructure.Services.Hashers;

namespace Maxanger.Infrastructure.Tests.Services;

public class AccessTicketEncryptorTests
{
    [Theory]
    [InlineData("aboba", "666")]
    [InlineData("345", "555")]
    public void EncryptAndDecrypt_Code_ReturnsLine(string key, string code)
    {
        var encryptor = new AccessTicketEncryptor(key);
        
        var encrypted = encryptor.Encrypt(code);
        var decrypted = encryptor.Decrypt(encrypted);
        
        Assert.Equal(code, decrypted);
    }
}