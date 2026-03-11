using Maxanger.Infrastructure.Entities.Abstract;
using Maxanger.Infrastructure.Entities.Chats;

namespace Maxanger.Infrastructure.Entities.Messages;

public class MessageContent : IEntity
{
    public long Id { get; set; }
    public long ChatMessageId { get; set; }
    
    public ChatMessage ChatMessage { get; set; }
}