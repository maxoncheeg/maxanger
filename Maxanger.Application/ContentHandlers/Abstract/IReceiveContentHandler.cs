using System.Text.Json;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Abstract;

public interface IReceiveContentHandler
{
    public MessageType Type { get; }
    public Task<string> HandleAsync(JsonElement payload);
}