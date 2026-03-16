using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IMessage
{
    public long Id { get; }
    public long ChatId { get; }
    public long FromId { get; }
    public MessageType Type { get; }
    public DateTime Date { get; }
    public string Payload { get; }
}