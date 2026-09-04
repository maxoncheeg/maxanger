using Maxanger.Infrastructure.Services.Hashers;

namespace Maxanger.Infrastructure.Tests.Services;

public class PasswordHasherTests
{
    [Theory]
    [InlineData("123")]
    [InlineData("7gdffs")]
    [InlineData("086")]
    public void HashAndVerify_Password_ReturnTrue(string password)
    {
        var hasher = new PasswordHasher();
        
        var hashedPassword = hasher.Hash(password);
        
        Assert.True(hasher.Verify(hashedPassword, password));
    }
}