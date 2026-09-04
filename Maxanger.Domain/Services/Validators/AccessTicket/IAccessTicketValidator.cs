namespace Maxanger.Domain.Services.Validators.AccessTicket;

public interface IAccessTicketValidator
{
    public bool IsValid(string code);
}