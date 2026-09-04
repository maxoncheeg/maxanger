using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Access;

public class AccessTicket : IEntity
{
    public long Id { get; private set; }
    public string Code { get; private set; } =  string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public AccessTicketType Type { get; private set; }
    public int Uses { get; private set; } = 0;
    public bool IsActive { get; private set; }

    public static AccessTicket Create(string code, DateTime expiresAt, AccessTicketType type,
        bool isActive)
    {
        if (expiresAt < DateTime.UtcNow)
            throw new DomainException("ACCESS_TICKET_EXPIRATION",
                "Access ticket expiration must be in future");

        if (code.Length <= 3)
            throw new DomainException("CODE_LENGTH",
                "Code lenght must be greater than or equal to 3");

        return new AccessTicket
        {
            Code = code,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = expiresAt,
            Type = type,
            IsActive = isActive
        };
    }

    public void Use()
    {
        if(!IsActive)
            throw new DomainException("CODE_NOT_ACTIVE",
                "Code not activated");

        Uses++;
        
        if(Type == AccessTicketType.Single)
            IsActive = false;
    }

    public void Activate()
    {
        if(IsActive)
            throw new DomainException("CODE_IS_ACTIVE",
                "Code already activated");
            
        IsActive = true;
    }
    
    public void Deactivate()
    {
        if(!IsActive)
            throw new DomainException("CODE_NOT_ACTIVE",
                "Code not activated");
        
        IsActive = false;
    }

    public void ChangeExpiration(DateTime expiresAt)
    {
        ExpiresAt = expiresAt;
    }
}