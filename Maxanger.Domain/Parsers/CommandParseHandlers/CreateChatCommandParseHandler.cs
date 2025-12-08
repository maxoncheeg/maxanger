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
        var isCommandMatch = Regex.IsMatch(command, @"^\/chat\s+create\s+(.+)$", RegexOptions.IgnoreCase);

        if (isCommandMatch)
        {
            var split = Regex.Split(command, @"\/chat\s+create\s+", RegexOptions.IgnoreCase);

            if (split.Length > 1)
            {
                var chatName = split[1].Trim();

                return new ParseResult(new ParsedCommand(Action, [chatName]));
            }
            else
                return new ParseResult(new ParsedCommand(Action))
                    { Error = "Не найдено имя чата (/chat create [NAME])." };
        }

        return new ParseResult(new ParsedCommand(Action))
            { Error = "Неверное написание команды (/chat create [NAME])." };
    }
}