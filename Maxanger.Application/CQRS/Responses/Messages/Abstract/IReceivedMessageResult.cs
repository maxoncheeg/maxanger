namespace Maxanger.Application.CQRS.Responses.Messages.Abstract;

public interface IReceivedMessageResult
{
    public long MessageId { get; }
    public DateTime ReceivedAt { get; }
}