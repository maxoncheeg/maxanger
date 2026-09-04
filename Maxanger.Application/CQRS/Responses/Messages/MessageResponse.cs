using Maxanger.Domain.Enums;

namespace Maxanger.Application.CQRS.Responses.Messages;

public record MessageResponse() 
{
    public long Id { get; set; }
    public long FromId { get; set; }
    public long ChatId { get; set; }
    public long? ReplyToId { get; set; }
    public MessageType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Content { get; set; } = string.Empty;
    public Dictionary<string, object>? Metadata { get; set; }
}