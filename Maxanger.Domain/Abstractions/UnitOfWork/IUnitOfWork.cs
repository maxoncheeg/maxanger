namespace Maxanger.Domain.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}