using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Commands;
using Maxanger.Domain.Models.Parsers;
using Maxanger.Domain.Models.Parsers.Abstract;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandParseHandlers;

public class CreateChatCommandParseHandler : ICommandParseHandler
{
    public CommandAction Action => CommandAction.ChatCreate;

    public IParseResult Parse(string command)
    {
        var isCommandMatch = Regex.IsMatch(command, @"^\/chat\s+create$", RegexOptions.IgnoreCase);

        if (isCommandMatch)
        {
                return new ParseResult(new ParsedCommand(Action, []));
        }

        return new ParseResult(new ParsedCommand(Action))
            { Error = "Неверное написание команды (/chat create)." };
    }
}