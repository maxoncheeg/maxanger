using Maxanger.Application.ContentHandlers.Send.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Send;

public class SendContentHandlerFactory : ISendContentHandlerFactory
{
    private readonly Dictionary<MessageType, ISendContentHandler> _handlers;
    private readonly IDefaultSendContentHandler _handler;

    public SendContentHandlerFactory(IDefaultSendContentHandler handler,
        IEnumerable<ISendContentHandler> handlers)
    {
        _handler = handler;
        _handlers = handlers.ToDictionary(h => h.Type, h => h);
    }

    public ISendContentHandler GetHandler(MessageType type)
    {
        return _handlers.GetValueOrDefault(type, _handler);
    }
}