namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollOption
{
    public long PoolId { get; set; }
    public string Text { get; set; }
    
    public Poll Poll { get; set; }
}