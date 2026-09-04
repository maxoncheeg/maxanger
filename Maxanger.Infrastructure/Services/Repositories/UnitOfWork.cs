using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Infrastructure.Contexts;

namespace Maxanger.Infrastructure.Services.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveAsync();
    }
}