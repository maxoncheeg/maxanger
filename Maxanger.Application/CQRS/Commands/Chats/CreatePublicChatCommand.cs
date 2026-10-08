using Maxanger.Application.CQRS.Responses.Chats;
using Maxanger.Domain.Enums;
using MediatR;

namespace Maxanger.Application.CQRS.Commands.Chats;

public record CreatePublicChatCommand(string ChatName, long UserId) : IRequest<ChatInfoDto>
{
    public IDictionary<long, MemberRole>? Users { get; set; }
}