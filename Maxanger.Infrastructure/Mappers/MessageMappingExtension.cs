using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Infrastructure.Entities.Messages;

namespace Maxanger.Infrastructure.Mappers;

public static class MessageMappingExtension
{
    public static MessageResponse ToMessageResponse(this Message message)
    {
        return new MessageResponse
        {
            Id = message.Id,
            CreatedAt = message.CreatedAt,
            UpdatedAt = message.UpdatedAt,
            Type = message.Type,
            FromId = message.FromId,
            Status = message.Status,
            ReplyToId = message.ReplyToMessageId,
            Payload = message.Payload,
            ChatId = message.ChatId
        };
    }
}