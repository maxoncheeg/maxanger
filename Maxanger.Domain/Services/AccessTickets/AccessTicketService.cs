using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;
using Maxanger.Domain.Repositories.AccessTicket;

namespace Maxanger.Domain.Services.AccessTickets;

public class AccessTicketService(
    IAccessTicketEncryptor accessTicketEncryptor,
    IAccessTicketRepository accessTicketRepository,
    IUnitOfWork unitOfWork) : IAccessTicketService
{
    public async Task<AccessTicket> CreateAccessTicketAsync(string code, AccessTicketType type, DateTime expiresAt,
        bool isActive,
        CancellationToken cancellationToken = default)
    {
        var accessTicket = AccessTicket.Create(accessTicketEncryptor.Encrypt(code), expiresAt, type, isActive);

        await accessTicketRepository.CreateAccessTicketAsync(accessTicket);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return accessTicket;
    }

    public async Task ChangeExpirationAsync(long ticketId, DateTime expiresAt,
        CancellationToken cancellationToken = default)
    {
        var ticket = await GetAccessTicketAsync(ticketId, cancellationToken);

        ticket.ChangeExpiration(expiresAt);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task ActivateAccessTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        var ticket = await GetAccessTicketAsync(ticketId, cancellationToken);

        ticket.Activate();

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAccessTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        var ticket = await GetAccessTicketAsync(ticketId, cancellationToken);

        ticket.Deactivate();

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UseAccessTicketCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var ticket =
            await accessTicketRepository.FindAccessTicketByCodeAsync(accessTicketEncryptor.Encrypt(code),
                cancellationToken);
        
        if(ticket == null)
            throw new DomainException("WRONG_ACCESS_TICKET_CODE", "Access ticket code not found");
        
        ticket.Use();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<AccessTicket> GetAccessTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        var ticket = await accessTicketRepository.FindAccessTicketByIdAsync(ticketId, cancellationToken);

        return ticket ?? throw new DomainException("TICKET_NOT_FOUND", "Ticket not found");
    }
}