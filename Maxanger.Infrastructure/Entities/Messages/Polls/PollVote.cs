namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollVote
{
    public int Id { get; set; }
    public long PollId { get; set; }
    public long UserId { get; set; }
    
    public User User { get; set; }
    public Poll Poll { get; set; }
}