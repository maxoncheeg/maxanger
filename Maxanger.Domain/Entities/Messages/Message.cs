using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Messages;

public class Message : IEntity
{
    public long Id { get; init; }
    public long ChatId { get; private set; }
    public long? ReplyToMessageId { get; private set; }
    public long FromId { get; private set; }
    public MessageType Type { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public Dictionary<string, object>? Metadata { get; private set; }
    public string Content { get; private set; } = null!;
    public bool SoftDeleted { get; private set; }

    public static Message Create(MessageType type, string content, long fromId, long chatId, Dictionary<string, object>? metadata,
        long? replyToMessageId)
    {
        if (string.IsNullOrEmpty(content))
            throw new DomainException("EMPTY_CONTENT", "Empty content");

        return new Message
        {
            Type = type,
            Content = content,
            FromId = fromId,
            ReplyToMessageId = replyToMessageId,
            Metadata = metadata,
            ChatId =  chatId
        };
    }

    public void Edit(string newContent)
    {
        if (string.IsNullOrWhiteSpace(newContent))
            throw new DomainException("EMPTY_CONTENT", "Empty content");

        Content = newContent;
    }

    public void Delete()
    {
        if (SoftDeleted)
            throw new DomainException("MESSAGE_DELETED", "Message already deleted");

        SoftDeleted = true;
    }

    public User From { get; private set; } = null!;
    public Message? ReplyToMessage { get; private set; }
    public IList<Message> Replies { get; private set; } = [];
    public Chat Chat { get; private set; } = null!;
}