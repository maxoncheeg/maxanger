using Maxanger.Domain.Enums;

namespace Maxanger.Application.CQRS.Responses.AccessTickets;

public class AccessTicketResponse 
{
    public long Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
    public AccessTicketType Type { get; init; }
    public bool IsActive { get; init; }
}