using Maxanger.Application.CQRS.Responses.AccessTickets;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.AccessTickets;

public record GetAccessTicketByCodeQuery(string Code) : IRequest<AccessTicketResponse>;