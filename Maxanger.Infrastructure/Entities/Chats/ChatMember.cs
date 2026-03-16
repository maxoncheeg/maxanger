using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Entities.Abstract;

namespace Maxanger.Infrastructure.Entities.Chats;

// todo: Если чела банят, а потом разбанят, он увидит всю переписку. Нужно хранить данные о банах в теории.
public class ChatMember : IEntity
{
    public long ChatId { get; set; }
    public long UserId { get; set; }
    public MemberStatus Status { get; set; }
    public MemberRole Role { get; set; }
    public DateTime AddedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Chat Chat { get; set; } = null!;
    public User User { get; set; } = null!;
}