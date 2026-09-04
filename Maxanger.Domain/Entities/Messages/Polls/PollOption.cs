using Maxanger.Domain.Entities.Abstract;

namespace Maxanger.Domain.Entities.Messages.Polls;

public class PollOption : IEntity
{
    public long Id { get; set; }
    public long PollId { get; set; }
    public string Text { get; set; } = null!;
    public long VotesCount { get; set; }

    public Poll Poll { get; set; } = null!;
    public IList<PollVote> PollVotes { get; set; } = null!;
}