using System.Text.Json;
using Maxanger.Application.ContentHandlers.Send.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Send;

public class ImageSendContentHandler(IDefaultSendContentHandler defaultSendContentHandler) : ISendContentHandler
{
    public MessageType Type => MessageType.Image;
    
    public async Task<string> HandleAsync(JsonElement payload)
    {
        return await defaultSendContentHandler.HandleAsync(payload);
    }
}