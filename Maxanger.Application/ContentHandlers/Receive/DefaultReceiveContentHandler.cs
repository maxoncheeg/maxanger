using System.Text.Json;
using Maxanger.Application.ContentHandlers.Receive.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Receive;

public class DefaultReceiveContentHandler : IDefaultReceiveContentHandler
{
    public MessageType Type => MessageType.Text;
    
    public Task<JsonElement> HandleAsync(string payload)
    {
        var parsed = JsonDocument.Parse(payload);
        var root = parsed.RootElement;
        return Task.FromResult(root.Clone());
    }
}