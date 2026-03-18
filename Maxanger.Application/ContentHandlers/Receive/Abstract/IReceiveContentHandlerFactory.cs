using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Receive.Abstract;

public interface IReceiveContentHandlerFactory
{
    public IReceiveContentHandler GetHandler(MessageType messageType);
}