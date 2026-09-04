using Maxanger.Application.CQRS.Commands.AccessTickets;
using Maxanger.Domain.Services.AccessTickets;
using MediatR;

namespace Maxanger.Application.Handlers.AccessTickets;

public class AccessTicketHandler(IAccessTicketService accessTicketService)
    : IRequestHandler<CreateAccessTicketCommand, long>
{
    public async Task<long> Handle(CreateAccessTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await accessTicketService.CreateAccessTicketAsync(request.Code, request.Type, request.ExpiresAt,
            request.IsActive,
            cancellationToken);

        return ticket.Id;
    }
}