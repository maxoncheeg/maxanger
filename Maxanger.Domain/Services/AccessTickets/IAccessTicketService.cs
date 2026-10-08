using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Services.AccessTickets;

public interface IAccessTicketService
{
    public Task<AccessTicket> CreateAccessTicketAsync(string code, AccessTicketType type, DateTime expiresAt,
        bool isActive,
        CancellationToken cancellationToken = default);

    public Task ChangeExpirationAsync(long ticketId, DateTime expiresAt, CancellationToken cancellationToken = default);
    public Task ActivateAccessTicketAsync(long ticketId, CancellationToken cancellationToken = default);
    public Task DeactivateAccessTicketAsync(long ticketId, CancellationToken cancellationToken = default);
    public Task UseAccessTicketCodeAsync(string code, CancellationToken cancellationToken = default);
}