using Maxanger.Domain.Enums;

namespace Maxanger.Application.ContentHandlers.Send.Abstract;

public interface ISendContentHandlerFactory
{
    public ISendContentHandler GetHandler(MessageType messageType);
}