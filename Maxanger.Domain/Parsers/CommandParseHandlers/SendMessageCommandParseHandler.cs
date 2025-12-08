using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Commands;
using Maxanger.Domain.Models.Parsers;
using Maxanger.Domain.Models.Parsers.Abstract;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandParseHandlers;

public class SendMessageCommandParseHandler : ICommandParseHandler
{
    public CommandAction Action => CommandAction.SendMessage;

    public IParseResult Parse(string command)
    {
        var match = Regex.Match(command, @"^\/m\s+(\d+)\s+(.+)$", RegexOptions.IgnoreCase);

        if (match.Success)
        {
            var id = match.Groups[1].Value;
            var text = match.Groups[2].Value;

            return new ParseResult(new ParsedCommand(Action, [id, text]));
        }

        return new ParseResult(new ParsedCommand(Action))
            { Error = "Неверное написание команды (/m [CHAT_ID] [TEXT])." };
    }
}