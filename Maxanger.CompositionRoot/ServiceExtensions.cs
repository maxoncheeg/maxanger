using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Repositories.AccessTicket;
using Maxanger.Domain.Repositories.Users;
using Maxanger.Domain.Services.AccessTickets;
using Maxanger.Domain.Services.Users;
using Maxanger.Domain.Services.Validators.Password;
using Maxanger.Infrastructure.Repositories.AccessTickets;
using Maxanger.Infrastructure.Repositories.Users;
using Maxanger.Infrastructure.Services.Hashers;
using Maxanger.Infrastructure.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Maxanger.CompositionRoot;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services
                .AddScoped<IUserRegistrationService, UserRegistrationService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAccessTicketService, AccessTicketService>()
                .AddScoped<IAccessTicketRepository, AccessTicketRepository>()
                .AddTransient<IPasswordHasher, PasswordHasher>()
                .AddTransient<IAccessTicketEncryptor, AccessTicketEncryptor>(p => new AccessTicketEncryptor("aboba"))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<IPasswordValidator, TestPasswordValidator>()
            ;
    }
}