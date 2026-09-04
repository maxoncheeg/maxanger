using System.Reflection;
using Maxanger.Domain.Entities.Access;
using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Entities.Users;
using Maxanger.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public IQueryable<Chat> Chats => Set<Chat>();
    public IQueryable<ChatMember> ChatMembers => Set<ChatMember>();
    public IQueryable<Message> ChatMessages => Set<Message>();
    
    public IQueryable<Message> Messages => Set<Message>();
    
    // public IQueryable<Poll> Polls => Set<Poll>();
    // public IQueryable<PollOption> PollOptions => Set<PollOption>();
    // public IQueryable<PollVote> PollVotes => Set<PollVote>();
    
    public IQueryable<User> Users => Set<User>();
    public IQueryable<UserCredentials> UserCredentials => Set<UserCredentials>();
    public IQueryable<AccessTicket> AccessTickets => Set<AccessTicket>();

    public async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await Set<TEntity>().AddAsync(entity);
    }

    public async Task CreateRangeAsync<TEntity>(IList<TEntity> entities) where TEntity : class
    {
        await Set<TEntity>().AddRangeAsync(entities);
    }

    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Add(entity);
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Update(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Remove(entity);
    }

    public void DeleteRange<TEntity>(IList<TEntity> entities) where TEntity : class
    {
        Set<TEntity>().RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }

    public async Task MigrateAsync()
    {
        await Database.MigrateAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }
}