using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Entities.Messages.Polls;

namespace Maxanger.Infrastructure.Entities.Chats;

public class ChatMessage
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