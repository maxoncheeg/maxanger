using System.Text.RegularExpressions;

namespace Maxanger.Domain.Services.Validators.Password;

public partial class PasswordValidator : IPasswordValidator
{
    private readonly Regex _passwordRegex = PasswordRegex();

    public bool IsValid(string password)
    {
        return _passwordRegex.IsMatch(password);
    }

    [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
    private static partial Regex PasswordRegex();
}