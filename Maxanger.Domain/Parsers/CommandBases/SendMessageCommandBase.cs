using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandBases;

public class SendMessageCommandBase : ICommandBase
{
    public string Command => "/m";
    public Predicate<string> SubcommandMatcher => (string sub) => Regex.IsMatch(sub, @"^(?:0|[1-9]\d{0,18})$", RegexOptions.IgnoreCase);
    public CommandAction Action => CommandAction.SendMessage;
}