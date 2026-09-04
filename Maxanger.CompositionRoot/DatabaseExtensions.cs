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
            options.UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.ConfigureDataSource(builder => builder.EnableDynamicJson());
                sqlOptions.MigrationsAssembly("Maxanger.Infrastructure");
            }), ServiceLifetime.Scoped);
        
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