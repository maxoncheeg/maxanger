using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Messages.Abstract;

public interface IMessageOnSend
{
    public long ChatId { get; }
    public long? ReplyToId { get; }
    public Dictionary<string, object>? Metadata { get; }
    public string Content { get; }
    public MessageType MessageType { get; }
}