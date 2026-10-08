using Maxanger.Domain.Enums;
using MediatR;

namespace Maxanger.Application.CQRS.Commands.AccessTickets;

public record CreateAccessTicketCommand(string Code, DateTime ExpiresAt, AccessTicketType Type, bool IsActive = true) : IRequest<long>;