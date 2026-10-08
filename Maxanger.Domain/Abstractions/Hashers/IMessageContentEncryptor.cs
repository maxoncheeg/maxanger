namespace Maxanger.Domain.Abstractions.Hashers;

public interface IMessageContentEncryptor
{
    public string Encrypt(string content);
    public string Decrypt(string encryptedContent);
}