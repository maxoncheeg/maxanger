namespace Maxanger.Domain.Services.Validators.Password;

public class TestPasswordValidator : IPasswordValidator
{
    public bool IsValid(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length > 0;
    }
}