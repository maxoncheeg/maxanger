namespace Maxanger.Application.Services.Abstract;

public interface IContentEncryptor
{
    public string Encrypt(string content);
    public string Decrypt(string crypt);
}