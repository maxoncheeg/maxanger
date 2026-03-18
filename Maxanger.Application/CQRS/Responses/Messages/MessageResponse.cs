using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Messages.Abstract;

namespace Maxanger.Application.CQRS.Responses.Messages;

public record MessageResponse() : IMessage
{
    public long Id { get; set; }
    public long FromId { get; set; }
    public long ChatId { get; set; }
    public long? ReplyToId { get; set; }
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Payload { get; set; } = string.Empty;
}