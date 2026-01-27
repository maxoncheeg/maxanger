namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class Poll : MessageContent
{
    public string Name { get; set; }
    
    public IList<PollOption> Options { get; set; }
    public IList<PollVote> Votes { get; set; }
}