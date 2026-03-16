namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IImageContent : IContent
{
    public string Text { get; set; }
    public string Name { get; set; }
}