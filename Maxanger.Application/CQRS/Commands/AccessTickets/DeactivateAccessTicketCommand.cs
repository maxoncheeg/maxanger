using MediatR;

namespace Maxanger.Application.CQRS.Commands.AccessTickets;

public record DeactivateAccessTicketCommand(long Id) : IRequest<bool>;