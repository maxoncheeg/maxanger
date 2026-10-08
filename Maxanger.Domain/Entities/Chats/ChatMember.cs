using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Chats;

// todo: Если чела банят, а потом разбанят, он увидит всю переписку. Нужно хранить данные о банах в теории.
public class ChatMember : IEntity
{
    public long ChatId { get; private set; }
    public long UserId { get; private set; }
    public MemberStatus Status { get; private set; }
    public MemberRole Role { get; private set; }
    public DateTime AddedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public bool SoftDeleted { get; private set; }

    public static ChatMember Create(long chatId, long userId, MemberStatus status, MemberRole role)
    {
        return new ChatMember
        {
            ChatId = chatId,
            UserId = userId,
            Status = status,
            Role = role
        };
    }

    public void Ban()
    {
        Status = MemberStatus.Banned;
    }

    public void Mute()
    {
        Status = MemberStatus.Muted;
    }

    public void RemoveStatus()
    {
        Status = MemberStatus.None;
    }

    public void Delete()
    {
        if(SoftDeleted)
            throw new DomainException("CHAT_MEMBER_DELETED", "Can't delete this member");
        
        SoftDeleted = true;
    }

    public Chat Chat { get; private set; } = null!;
    public User User { get; private set; } = null!;
}