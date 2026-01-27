namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollOption
{
    public long Id { get; set; }
    public long PollId { get; set; }
    public string Text { get; set; }
    
    public Poll Poll { get; set; }
}