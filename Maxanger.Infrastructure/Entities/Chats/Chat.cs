using Maxanger.Infrastructure.Entities.Abstract;
using Maxanger.Infrastructure.Entities.Messages;

namespace Maxanger.Infrastructure.Entities.Chats;

public class Chat : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool SoftDeleted { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; }
    public IList<Message> ChatMessages { get; set; }
}