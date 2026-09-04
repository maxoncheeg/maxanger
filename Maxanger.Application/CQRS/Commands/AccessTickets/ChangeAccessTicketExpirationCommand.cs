using MediatR;

namespace Maxanger.Application.CQRS.Commands.AccessTickets;

public record ChangeAccessTicketExpirationCommand(long Id, DateTime ExpiresAt, bool IsActive) : IRequest<long>;