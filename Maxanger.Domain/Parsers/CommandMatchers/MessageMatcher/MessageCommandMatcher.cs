using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandMatchers.MessageMatcher;

public partial class MessageCommandMatcher() : AbstractRegexCommandMatcher(CommandAction.SendMessage), IMessageCommandMatcher
{
    protected override Regex GetMatchRegex() => CommandRegex();

    [GeneratedRegex(@"^/m(\s)+(.+)$", RegexOptions.IgnoreCase)]
    private static partial Regex CommandRegex();
}