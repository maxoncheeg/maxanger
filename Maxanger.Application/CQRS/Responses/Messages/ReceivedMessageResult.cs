using Maxanger.Application.CQRS.Responses.Messages.Abstract;

namespace Maxanger.Application.CQRS.Responses.Messages;

public record ReceivedMessageResult(long MessageId, DateTime ReceivedAt) : IReceivedMessageResult;