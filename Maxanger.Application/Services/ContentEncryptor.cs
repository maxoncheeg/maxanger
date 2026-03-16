using Maxanger.Application.Services.Abstract;

namespace Maxanger.Application.Services;

public class ContentEncryptor: IContentEncryptor
{
    public string Encrypt(string content)
    {
        return content;
    }

    public string Decrypt(string crypt)
    {
        return crypt;
    }
}