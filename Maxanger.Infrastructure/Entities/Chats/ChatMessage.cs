using Maxanger.Infrastructure.Entities.Abstract;
using Maxanger.Infrastructure.Entities.Messages;

namespace Maxanger.Infrastructure.Entities.Chats;

public class ChatMessage : IEntity
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public DateTime Date { get; set; }
    public long FromId { get; set; }
    public bool SoftDeleted { get; set; }
    
    public User From { get; set; }
    public Chat Chat { get; set; }
    public MessageContent Content { get; set; }
}