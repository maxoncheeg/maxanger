using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Entities.Users;

namespace Maxanger.Domain.Entities.Messages.Polls;

public class PollVote : IEntity
{
    public long UserId { get; set; }
    public long PollOptionId { get; set; }
    public User User { get; set; } = null!;
    public PollOption PollOption { get; set; } = null!;
}