using System.Text.Json;
using Maxanger.Application.ContentHandlers.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers;

public class ImageReceiveContentHandler(IDefaultReceiveContentHandler defaultReceiveContentHandler) : IReceiveContentHandler
{
    public MessageType Type => MessageType.Image;
    
    public async Task<string> HandleAsync(JsonElement payload)
    {
        return await defaultReceiveContentHandler.HandleAsync(payload);
    }
}