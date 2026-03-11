using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandMatchers.ChatMatcher;

public class ChatCreateCommandMatcher() : AbstractRegexCommandMatcher(CommandAction.ChatCreate), IChatCommandMatcher
{
    protected override Regex GetMatchRegex() => new(@"^/chat(\s)+create", RegexOptions.IgnoreCase);
}