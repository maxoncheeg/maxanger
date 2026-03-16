using Maxanger.Infrastructure.Contexts;
using Maxanger.Infrastructure.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Maxanger.CompositionRoot;

public static class DatabaseExtensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection @this, string connectionString)
    {
        @this.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, x => x.MigrationsAssembly("Maxanger.Infrastructure")), ServiceLifetime.Transient);
        
        // using var scope = @this.BuildServiceProvider().CreateScope();
        // var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        // await context.MigrateAsync();

        return @this;
    }

    public static async Task<IServiceCollection> MigratePostgresDatabaseAsync(this IServiceCollection @this)
    {
        // using var scope = @this.BuildServiceProvider().CreateScope();
        // var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        // await context.MigrateAsync();
        
        return @this;
    }
}