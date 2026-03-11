using Maxanger.Infrastructure.Entities.Abstract;

namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollVote : IEntity
{
    public int Id { get; set; }
    public long PollId { get; set; }
    public long UserId { get; set; }
    
    public User User { get; set; }
    public Poll Poll { get; set; }
}