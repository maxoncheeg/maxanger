using Maxanger.Application.CQRS.Commands.Chats;
using Maxanger.Application.CQRS.Responses.Chats;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Domain.Services.Chats;
using MediatR;

namespace Maxanger.Application.Handlers.Chats;

public class CreateChatHandler(IChatService chatService) : IRequestHandler<CreatePublicChatCommand, ChatInfoDto>
{
    public async Task<ChatInfoDto> Handle(CreatePublicChatCommand request, CancellationToken cancellationToken)
    {
        var chat =
            await chatService.CreatePublicChatAsync(request.ChatName, request.UserId, request.Users, cancellationToken);
        var username = "abobius" + request.UserId;
        var message = chat.ChatMessages.FirstOrDefault();
        
        LastChatMessageDto? lastChatMessage = null;
        if (message != null)
        {
            lastChatMessage = new LastChatMessageDto
            {
                Id = message.Id,
                CreatedAt = message.CreatedAt,
                UpdatedAt = message.UpdatedAt,
                FromId = message.FromId,
                ChatId = message.ChatId,
                Type = message.Type,
                Content = message.Content,
                Metadata = message.Metadata,
                Username = username
            };
        }

        return new ChatInfoDto
        {
            Id = chat.Id,
            Name = chat.Name,
            Type = chat.Type,
            LastMessage = lastChatMessage
        };
    }
}