namespace Maxanger.Domain.Entities.Messages.Polls;

public class Poll
{
    public long Id { get; set; }
    public long MessageId { get; set; }
    public string Name { get; set; }

    public Message Message { get; set; } = null!;
    public IList<PollOption> Options { get; set; }
}