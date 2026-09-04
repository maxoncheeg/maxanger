using Maxanger.Application.CQRS.Commands.AccessTickets;
using Maxanger.Application.CQRS.Commands.Register;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Application.Handlers.AccessTickets;
using Maxanger.Application.Handlers.Registration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Maxanger.CompositionRoot;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
    {
        // services
        //     .AddTransient<IRequestHandler<GetChatMemberInfoByUserIdQuery, GetChatMemberInfoByUserIdResponse?>,
        //         GetChatMemberHandler>()
        
        // commands
        services
            .AddTransient<IRequestHandler<CreateAccessTicketCommand, long>,
                AccessTicketHandler>()
            
            .AddTransient<IRequestHandler<RegisterUserWithCodeCommand, UserDto>,
                UserRegistrationHandler>()
            
            ;
        

        return services;
    }
}