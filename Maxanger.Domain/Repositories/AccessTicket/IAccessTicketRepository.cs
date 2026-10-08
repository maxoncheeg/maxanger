namespace Maxanger.Domain.Repositories.AccessTicket;

public interface IAccessTicketRepository
{
    public Task<Entities.Access.AccessTicket?> FindAccessTicketByCodeAsync(string code, CancellationToken cancellationToken = default);
    public Task<Entities.Access.AccessTicket?> FindAccessTicketByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task CreateAccessTicketAsync(Entities.Access.AccessTicket accessTicket);
}