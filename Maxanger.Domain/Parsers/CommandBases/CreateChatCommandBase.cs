using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandBases;

public class CreateChatCommandBase : ICommandBase
{
    public string Command => "/chat";
    public Predicate<string> SubcommandMatcher => (string sub) => Regex.IsMatch(sub, @"^create$", RegexOptions.IgnoreCase);
    public CommandAction Action => CommandAction.ChatCreate;
}