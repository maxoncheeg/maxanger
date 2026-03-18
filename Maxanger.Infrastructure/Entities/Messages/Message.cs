using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Entities.Abstract;
using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages.Polls;

namespace Maxanger.Infrastructure.Entities.Messages;

public class Message : IEntity
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public long? ReplyToMessageId { get; set; }
    public long FromId { get; set; }
    public MessageType Type { get; set; }
    public MessageStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Payload { get; set; } = null!;
    public bool SoftDeleted { get; set; }
    
    
    public User From { get; set; } = null!;
    public Message? ReplyToMessage { get; set; }
    public IList<Message> Replies { get; set; } = new List<Message>();
    public Chat Chat { get; set; } = null!;
    public Poll? Poll { get; set; }
}