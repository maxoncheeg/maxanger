using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IEventContent : IContent
{
    public long AffectedUserId { get; }
    public MemberStatus NewStatus { get; }
    public MemberStatus PreviousStatus { get; }
}