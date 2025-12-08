using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Commands;
using Maxanger.Domain.Models.Parsers;
using Maxanger.Domain.Models.Parsers.Abstract;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers;

public class CommandParser(ICommandAnalyzer commandAnalyzer, ICommandParseHandlerFactory commandParseHandlerFactory) : ICommandParser
{
    public IParseResult Parse(string command)
    {
        var commandAction = commandAnalyzer.Analyze(command);
        if (commandAction == CommandAction.Error)
            return new ParseResult(new ParsedCommand(commandAction))
                { Error = $"Несуществующая команда." };
        
        var commandParseHandler = commandParseHandlerFactory.GetParseHandler(commandAction);

        if (commandParseHandler == null)
            return new ParseResult(new ParsedCommand(commandAction))
                { Error = $"Нет обработчика команды {commandAction.ToString()}." };
        
        return commandParseHandler.Parse(command);
    }
}