using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Domain.Enums;
using Maxanger.Infrastructure.Contexts.Abstract;
using Maxanger.Infrastructure.Entities.Messages;
using Maxanger.Infrastructure.Mappers;
using MediatR;

namespace Maxanger.Infrastructure.Handlers.Messages;

public class SendMessageHandler(IApplicationDbContext context) : IRequestHandler<SendMessageCommand, MessageResponse?>
{
    public async Task<MessageResponse?> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            ChatId = request.ChatId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Type = request.Type,
            Payload = request.Payload,
            Status = MessageStatus.Received,
            FromId = request.UserId,
            ReplyToMessageId = request.ReplyToId ?? null
        };

        try
        {
           await context.CreateAsync(message);
           await context.SaveAsync();

           return message.ToMessageResponse();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return null;
        }
    }
}