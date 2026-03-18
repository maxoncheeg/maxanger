using System.Text.Json;
using Maxanger.Application.ContentHandlers.Send.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Send;

//IContentEncryptor encryptor
public class DefaultSendContentHandler() : IDefaultSendContentHandler
{
    // todo: костыль как-будто :D
    public MessageType Type => MessageType.Text;

    public Task<string> HandleAsync(JsonElement payload)
    {
        // return Task.FromResult(encryptor.Encrypt(payload.GetRawText()));
        return Task.FromResult(payload.GetRawText());
    }
}