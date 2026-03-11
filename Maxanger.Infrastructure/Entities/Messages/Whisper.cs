namespace Maxanger.Infrastructure.Entities.Messages;

public class Whisper : MessageContent
{
    public string Text { get; set; }
    public long ToId { get; set; }
    
    public User To { get; set; }
}