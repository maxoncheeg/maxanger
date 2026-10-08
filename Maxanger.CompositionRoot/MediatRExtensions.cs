using Maxanger.Application.CQRS.Commands.AccessTickets;
using Maxanger.Application.CQRS.Commands.Chats;
using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Commands.Register;
using Maxanger.Application.CQRS.Queries.Messages;
using Maxanger.Application.CQRS.Responses.Chats;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Application.Handlers.AccessTickets;
using Maxanger.Application.Handlers.Chats;
using Maxanger.Application.Handlers.Messages;
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
            
            .AddTransient<IRequestHandler<CreatePublicChatCommand, ChatInfoDto>,
                CreateChatHandler>()
            
            .AddTransient<IRequestHandler<SendMessageCommand, long>, SendMessageHandler>()
            .AddTransient<IRequestHandler<GetMessagesQuery, IList<MessageDto>>, GetMessagesHandler>()
            
            ;
        

        return services;
    }
}