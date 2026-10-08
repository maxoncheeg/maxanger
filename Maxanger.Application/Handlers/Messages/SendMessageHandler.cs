using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Domain.Services.Messages;
using MediatR;

namespace Maxanger.Application.Handlers.Messages;

public class SendMessageHandler(ISendMessageService sendMessageService) : IRequestHandler<SendMessageCommand, long>
{
    public async Task<long> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await sendMessageService.SendMessageAsync(request.UserId, request.ChatId, request.Content, request.Type,
            request.Metadata, request.ReplyToId, cancellationToken);

        return message.Id;
    }
}