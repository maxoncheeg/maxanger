using Maxanger.Infrastructure.Entities.Abstract;

namespace Maxanger.Infrastructure.Entities.Chats;

public class Chat : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool SoftDeleted { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; }
    public IList<ChatMessage> ChatMessages { get; set; }
}