using System.Text.Json;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Send.Abstract;

public interface ISendContentHandler
{
    public MessageType Type { get; }
    public Task<string> HandleAsync(JsonElement payload);
}