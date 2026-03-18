namespace Maxanger.Application.Services.Messages.Abstract;

public interface IContentEncryptor
{
    public string Encrypt(string content);
    public string Decrypt(string crypt);
}