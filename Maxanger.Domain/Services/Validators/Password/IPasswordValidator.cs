namespace Maxanger.Domain.Services.Validators.Password;

public interface IPasswordValidator
{
    public bool IsValid(string password);
}