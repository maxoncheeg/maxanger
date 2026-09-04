using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Messages.Abstract;

public interface ILastChatMessage
{
    public long Id { get; }
    public long FromId { get; }
    public long? ReplyToId { get; }
    public long ChatId { get; }
    public MessageType Type { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public string Content { get; set; }
    public Dictionary<string, object>? Metadata { get; }
    public string Username { get; }
}