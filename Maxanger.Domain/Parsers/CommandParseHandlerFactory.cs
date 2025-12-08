using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers;

public class CommandParseHandlerFactory : ICommandParseHandlerFactory
{
    private readonly Dictionary<CommandAction, ICommandParseHandler> _parsers;

    public CommandParseHandlerFactory(IEnumerable<ICommandParseHandler> parsers)
    {
        _parsers = parsers.ToDictionary(parser => parser.Action, parser => parser);
    }

    public ICommandParseHandler? GetParseHandler(CommandAction action) => _parsers.GetValueOrDefault(action);
}