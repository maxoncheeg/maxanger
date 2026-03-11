using Maxanger.Infrastructure.Entities;
using Maxanger.Infrastructure.Entities.Chats;
using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Entities.Messages.Polls;

namespace Maxanger.Infrastructure.Contexts.Abstract;

public interface IApplicationDbContext: IDbContext
{
    IQueryable<Chat> Chats { get; }
    IQueryable<ChatMember> ChatMembers { get; }
    IQueryable<ChatMessage> ChatMessages { get; }

    IQueryable<Message> Messages { get; }
    IQueryable<Event> Events { get; }
    IQueryable<Whisper> Whispers { get; }
    
    IQueryable<Poll> Polls { get; }
    IQueryable<PollOption> PollOptions { get; }
    IQueryable<PollVote> PollVotes { get; }
    
    IQueryable<User> Users { get; }
    IQueryable<UserCredentials> UserCredentials { get; }
    
    
}