using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Queries.ChatMembers;
using Maxanger.Application.CQRS.Queries.Messages;
using Maxanger.Application.CQRS.Queries.Users;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Infrastructure.Handlers.ChatMembers;
using Maxanger.Infrastructure.Handlers.Messages;
using Maxanger.Infrastructure.Handlers.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Maxanger.CompositionRoot;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<GetChatMemberInfoByUserIdQuery, GetChatMemberInfoByUserIdResponse?>,
                GetChatMemberHandler>()
            
            
            .AddTransient<IRequestHandler<GetMessagesByIdsQuery, IList<MessageResponse>>,
                GetMessagesHandler>()
            .AddTransient<IRequestHandler<GetMessagesQuery, IList<MessageResponse>>,
                GetMessagesHandler>()
            
            .AddTransient<IRequestHandler<GetMessageWritersByIdsQuery, IList<MessageWriterResponse>>,
                GetMessageWriterHandler>()
            ;
        
        // commands
        services
            .AddTransient<IRequestHandler<SendMessageCommand, MessageResponse?>,
                SendMessageHandler>();

        return services;
    }
}