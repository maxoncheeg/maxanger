using System.Text.Json.Serialization;
using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Messages;

public class SentMessage : ISentMessage
{
    public long Id { get; init; }
    public long FromId { get; init; }
    public long ChatId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? ReplyToId { get; init; }

    public MessageType Type { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public Dictionary<string, object>? Metadata { get; init; }
    public string Content { get; init; }
}