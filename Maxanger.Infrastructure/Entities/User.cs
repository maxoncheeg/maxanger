using Maxanger.Infrastructure.Entities.Chats;

namespace Maxanger.Infrastructure.Entities;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; }
    public IList<ChatMessage> ChatMessages { get; set; }
}