namespace Maxanger.Infrastructure.Entities.Chats;

public class MemberStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; }
}