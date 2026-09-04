using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Chats;

public class Chat : IEntity
{
    public long Id { get; private set; }
    public string? Name { get; private set; }
    public ChatType Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool SoftDeleted { get; private set; }

    public static Chat Create(ChatType type, string? name)
    {
        if (type != ChatType.Direct && string.IsNullOrEmpty(name))
            throw new DomainException("CHAT_REQUIRED_NAME", $"This type of chat required name ({type.ToString()})");

        if (type != ChatType.Direct && name!.Length <= 3)
            throw new DomainException("CHAT_NAME_LENGTH", "Chat name must be at least 3 characters long");

        return new Chat
        {
            Type = type,
            Name = name,
        };
    }

    public void AddMember(long userId, MemberRole role, MemberStatus status)
    {
        var chatMember = ChatMember.Create(Id, userId, status, role);
        
        ChatMembers.Add(chatMember);
    }

    public void Delete()
    {
        if(SoftDeleted)
            throw new DomainException("CHAT_DELETED", "Chat already deleted");
        
        SoftDeleted = true;
    }

    public IList<ChatMember> ChatMembers { get; private set; } = [];
    public IList<Message> ChatMessages { get; private set; } = [];
}