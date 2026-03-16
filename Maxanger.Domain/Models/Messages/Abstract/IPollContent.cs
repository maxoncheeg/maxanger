namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IPollContent : IContent
{
    public string? Description { get; }
}