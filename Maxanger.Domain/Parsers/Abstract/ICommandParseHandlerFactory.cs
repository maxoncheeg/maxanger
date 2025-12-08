using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandParseHandlerFactory
{
    public ICommandParseHandler? GetParseHandler(CommandAction action);
}