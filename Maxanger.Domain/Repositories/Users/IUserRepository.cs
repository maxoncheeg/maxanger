using Maxanger.Domain.Entities.Users;

namespace Maxanger.Domain.Repositories.Users;

public interface IUserRepository
{
    public Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    public Task<User?> FindUserByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task<User?> FindUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    public void CreateUser(User user);
}