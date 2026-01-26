namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollVote
{
    public long PoolId { get; set; }
    public long UserId { get; set; }
    
    public User User { get; set; }
    public Poll Poll { get; set; }
}