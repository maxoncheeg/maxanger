using Maxanger.Infrastructure.Entities.Chats;

namespace Maxanger.Infrastructure.Entities.Messages;

public class Event : MessageContent
{
    public int StatusTypeId { get; set; }
    public long AffectedUserId { get; set; }

    public User AffectedUser { get; set; }
    public MemberStatusType StatusType { get; set; }
}