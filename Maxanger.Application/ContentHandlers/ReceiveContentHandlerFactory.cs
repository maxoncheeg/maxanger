using Maxanger.Application.ContentHandlers.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers;

public class ReceiveContentHandlerFactory : IReceiveContentHandlerFactory
{
    private readonly Dictionary<MessageType, IReceiveContentHandler> _handlers;
    private readonly IDefaultReceiveContentHandler _handler;

    public ReceiveContentHandlerFactory(IDefaultReceiveContentHandler handler,
        IEnumerable<IReceiveContentHandler> handlers)
    {
        _handler = handler;
        _handlers = handlers.ToDictionary(h => h.Type, h => h);
    }

    public IReceiveContentHandler GetHandler(MessageType type)
    {
        return _handlers.GetValueOrDefault(type, _handler);
    }
}