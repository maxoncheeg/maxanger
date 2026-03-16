namespace Maxanger.Domain.Models.Messages.Abstract;

public interface ITextContent : IContent
{
    public string Text { get; }
}