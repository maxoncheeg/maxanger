using Maxanger.Application.CQRS.Responses.Messages.Abstract;
using Maxanger.Application.Models.Messages.Abstract;

namespace Maxanger.Application.Services.Abstract;

public interface IMessageService
{
    public Task<IReceivedMessageResult?> ReceiveMessageAsync(IReceivedMessage receivedMessage);
}