using Maxanger.Application.Services.Messages.Abstract;

namespace Maxanger.Application.Services.Messages;

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