using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Application.Models.Messages.Abstract;
using MediatR;

namespace Maxanger.Application.CQRS.Commands.Messages;

public record ReceiveMessageCommand(IReceivedMessage Message) : IRequest<ReceivedMessageResult>;