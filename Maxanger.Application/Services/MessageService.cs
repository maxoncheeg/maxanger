using Maxanger.Application.ContentHandlers.Abstract;
using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Responses.Messages.Abstract;
using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Application.Services.Abstract;
using MediatR;

namespace Maxanger.Application.Services;

public class MessageService(IMediator mediator, IReceiveContentHandlerFactory receiveContentHandlerFactory)
    : IMessageService
{
    public async Task<IReceivedMessageResult?> ReceiveMessageAsync(IReceivedMessage receivedMessage)
    {
        var handledContent = await receiveContentHandlerFactory.GetHandler(receivedMessage.MessageType)
            .HandleAsync(receivedMessage.Payload);

        var result = await mediator.Send(new ReceiveMessageCommand(receivedMessage));

        return result;
    }
}