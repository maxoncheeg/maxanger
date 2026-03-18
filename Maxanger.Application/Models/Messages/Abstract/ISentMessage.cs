using System.Text.Json;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Messages.Abstract;

public interface ISentMessage
{
    public long Id { get; }
    public long FromId { get; }
    public long ChatId { get; }
    public long? ReplyToId { get; }
    public MessageType Type { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public JsonElement Payload { get; }
    
}