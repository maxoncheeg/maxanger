using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Models.Users.Abstract;

public interface IChatMember
{
    public MemberStatus Status { get; }
    public MemberRole Role { get; }
}