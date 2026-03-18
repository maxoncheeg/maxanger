using Maxanger.Application.ContentHandlers.Receive;
using Maxanger.Application.ContentHandlers.Receive.Abstract;
using Maxanger.Application.ContentHandlers.Send;
using Maxanger.Application.ContentHandlers.Send.Abstract;
using Maxanger.Application.Services.Messages;
using Maxanger.Application.Services.Messages.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Maxanger.CompositionRoot;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IMessageService, MessageService>()
            .AddTransient<IDefaultReceiveContentHandler, DefaultReceiveContentHandler>()
            .AddTransient<IDefaultSendContentHandler, DefaultSendContentHandler>()
            .AddTransient<IReceiveContentHandlerFactory, ReceiveContentHandlerFactory>()
            .AddTransient<ISendContentHandlerFactory, SendContentHandlerFactory>()
            ;
        
    }
}