using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Factories.Messages;

public interface IMessageFactory
{
    public Message Create(MessageType type, string content, long fromId, Dictionary<string, object>? metadata, long? replyToMessageId);
}