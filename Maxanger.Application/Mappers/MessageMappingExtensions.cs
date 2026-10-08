using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Domain.Entities.Messages;

namespace Maxanger.Application.Mappers;

public static class MessageMappingExtensions
{
    public static MessageDto ToMessageDto(this Message @this)
    {
        return new MessageDto
        {
            Id = @this.Id,
            CreatedAt = @this.CreatedAt,
            Type = @this.Type,
            ChatId = @this.ChatId,
            FromId = @this.FromId,
            Content = @this.Content,
            Metadata = @this.Metadata,
            ReplyToId = @this.ReplyToMessageId,
            UpdatedAt = @this.UpdatedAt
        };
    }
}