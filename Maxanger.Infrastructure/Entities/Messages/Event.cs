namespace Maxanger.Infrastructure.Entities.Messages;

public class Event  : MessageContent
{
    public string Type { get; set; }
    public long AffectedUserId { get; set; }

    public User AffectedUser { get; set; }
}