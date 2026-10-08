using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Repositories.AccessTicket;
using Maxanger.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Repositories.AccessTickets;

public class AccessTicketRepository(IApplicationDbContext context) : IAccessTicketRepository
{
    public async Task<AccessTicket?> FindAccessTicketByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await context.AccessTickets.SingleOrDefaultAsync(t => t.Code == code, cancellationToken);
    }

    public async Task<AccessTicket?> FindAccessTicketByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.AccessTickets.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task CreateAccessTicketAsync(AccessTicket accessTicket)
    {
        await context.CreateAsync(accessTicket);
    }
}