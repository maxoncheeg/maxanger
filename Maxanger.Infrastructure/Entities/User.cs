using Maxanger.Infrastructure.Entities.Abstract;
using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Entities.Messages.Polls;

namespace Maxanger.Infrastructure.Entities;

public class User : IEntity
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public IList<ChatMember> ChatMembers { get; set; } = null!;
    public IList<Message> ChatMessages { get; set; } = null!;
    public IList<PollVote> PollVotes { get; set; } = null!;
    public UserCredentials UserCredentials { get; set; } = null!;
}