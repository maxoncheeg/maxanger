using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Domain.Enums;
using MediatR;

namespace Maxanger.Application.CQRS.Commands.Messages;

public record SendMessageCommand(long UserId, long ChatId, string Payload, MessageType Type, long? ReplyToId = null) : IRequest<MessageResponse>;