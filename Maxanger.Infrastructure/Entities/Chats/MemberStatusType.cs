using Maxanger.Infrastructure.Entities.Messages;

namespace Maxanger.Infrastructure.Entities.Chats;

public class MemberStatusType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; }
    public IList<Event> Events { get; set; }
}