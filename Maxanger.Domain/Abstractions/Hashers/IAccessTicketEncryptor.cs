namespace Maxanger.Domain.Abstractions.Hashers;

public interface IAccessTicketEncryptor
{
    public string Encrypt(string code);
    public string Decrypt(string code);
}