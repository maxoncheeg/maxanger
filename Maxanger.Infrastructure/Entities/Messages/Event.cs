using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Entities.Chats;

namespace Maxanger.Infrastructure.Entities.Messages;

public class Event : MessageContent
{
    public MemberStatus NewStatus { get; set; }
    public MemberStatus PreviousStatus { get; set; }
    public long AffectedUserId { get; set; }

    public User AffectedUser { get; set; }
}