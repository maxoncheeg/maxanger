namespace Maxanger.Infrastructure.Entities.Chats;

// todo: Если чела банят, а потом разбанят, он увидит всю переписку. Нужно хранить данные о банах в теории.
public class ChatMember
{
    public long ChatId { get; set; }
    public long UserId { get; set; }
    public int MemberStatusId { get; set; }
    public int MemberRoleId { get; set; }
    
    public MemberStatusType MemberStatusType { get; set; }
    public MemberRole MemberRole { get; set; }
    public Chat Chat { get; set; }
    public User User { get; set; }
}