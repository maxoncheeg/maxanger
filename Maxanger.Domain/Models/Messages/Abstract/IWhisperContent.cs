namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IWhisperContent : IContent
{
    public string Text { get; }
    public long ToId { get; }
}