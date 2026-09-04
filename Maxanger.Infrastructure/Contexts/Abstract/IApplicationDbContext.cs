using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Entities.Users;

namespace Maxanger.Infrastructure.Contexts.Abstract;

public interface IApplicationDbContext: IDbContext
{
    IQueryable<Chat> Chats { get; }
    IQueryable<ChatMember> ChatMembers { get; }
    IQueryable<Message> ChatMessages { get; }

    IQueryable<Message> Messages { get; }
    
    // IQueryable<Poll> Polls { get; }
    // IQueryable<PollOption> PollOptions { get; }
    // IQueryable<PollVote> PollVotes { get; }
    
    IQueryable<User> Users { get; }
    IQueryable<UserCredentials> UserCredentials { get; }
    IQueryable<AccessTicket> AccessTickets { get; }
    
    
}