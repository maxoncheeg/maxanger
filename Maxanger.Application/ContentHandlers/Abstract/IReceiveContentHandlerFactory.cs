using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Abstract;

public interface IReceiveContentHandlerFactory
{
    public IReceiveContentHandler GetHandler(MessageType messageType);
}