using System.Text.Json;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Receive.Abstract;

public interface IReceiveContentHandler
{
    public MessageType Type { get; }
    public Task<JsonElement> HandleAsync(string payload);
}