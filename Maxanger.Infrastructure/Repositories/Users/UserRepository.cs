using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Repositories.Users;
using Maxanger.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Repositories.Users;

public class UserRepository(IApplicationDbContext context) : IUserRepository
{
    public async Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> FindUserByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> FindUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public void CreateUser(User user)
    {
        context.Create(user);
    }
}