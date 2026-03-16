using System.Text.Json;
using Maxanger.Application.ContentHandlers.Abstract;
using Maxanger.Application.Services.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers;

public class DefaultReceiveContentHandler(IContentEncryptor encryptor) : IDefaultReceiveContentHandler
{
    // todo: костыль как-будто :D
    public MessageType Type => MessageType.Text;

    public Task<string> HandleAsync(JsonElement payload)
    {
        return Task.FromResult(encryptor.Encrypt(payload.GetRawText()));
    }
}