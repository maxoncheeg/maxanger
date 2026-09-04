using Maxanger.Domain.Entities.Users;

namespace Maxanger.Domain.Services.Users;

public interface IUserRegistrationService
{
    public Task<User> RegisterUser(string username, string email, string password,
        CancellationToken cancellationToken = default);
}