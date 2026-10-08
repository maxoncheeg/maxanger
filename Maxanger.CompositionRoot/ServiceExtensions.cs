using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Repositories.AccessTicket;
using Maxanger.Domain.Repositories.Chats;
using Maxanger.Domain.Repositories.Messages;
using Maxanger.Domain.Repositories.Users;
using Maxanger.Domain.Services.AccessTickets;
using Maxanger.Domain.Services.Chats;
using Maxanger.Domain.Services.Messages;
using Maxanger.Domain.Services.Users;
using Maxanger.Domain.Services.Validators.Password;
using Maxanger.Infrastructure.Repositories.AccessTickets;
using Maxanger.Infrastructure.Repositories.Chats;
using Maxanger.Infrastructure.Repositories.Messages;
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
                // users
                .AddScoped<IUserRegistrationService, UserRegistrationService>()
                .AddScoped<IUserRepository, UserRepository>()
                
                // access tickets
                .AddScoped<IAccessTicketService, AccessTicketService>()
                .AddScoped<IAccessTicketRepository, AccessTicketRepository>()
                
                // chats
                .AddScoped<IChatService, ChatService>()
                .AddScoped<IChatRepository, ChatRepository>()
                
                // messages
                .AddScoped<ISendMessageService, SendMessageService>()
                .AddScoped<IGetMessagesService, GetMessagesService>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IGetMessagesRepository, GetMessagesRepository>()
                
                // encrypt
                .AddTransient<IPasswordHasher, PasswordHasher>()
                .AddTransient<IAccessTicketEncryptor, AccessTicketEncryptor>(p => new AccessTicketEncryptor("aboba"))
                .AddTransient<IMessageContentEncryptor, MessageContentEncryptor>(p =>
                    new MessageContentEncryptor("ppq0ZDCeSVHVPe6jfQqQAbD/x0SfqvqSTJB+5E2tOpg="))
                
                // other
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<IPasswordValidator, TestPasswordValidator>()
            ;
    }
}