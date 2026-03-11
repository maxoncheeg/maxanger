using Maxanger.Infrastructure.Entities.Abstract;

namespace Maxanger.Infrastructure.Entities.Messages.Polls;

public class PollOption : IEntity
{
    public long Id { get; set; }
    public long PollId { get; set; }
    public string Text { get; set; }
    
    public Poll Poll { get; set; }
}