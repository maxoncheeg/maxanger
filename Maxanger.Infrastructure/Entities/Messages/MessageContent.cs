using Maxanger.Infrastructure.Entities.Chats;

namespace Maxanger.Infrastructure.Entities.Messages;

public class MessageContent
{
    public long Id { get; set; }
    
    public ChatMessage ChatMessage { get; set; }
}