using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.CommandMatchers.ChatMatcher;

public partial class ChatCreateCommandMatcher() : AbstractRegexCommandMatcher(CommandAction.ChatCreate), IChatCommandMatcher
{
    protected override Regex GetMatchRegex() => CreateChatRegex();

    [GeneratedRegex(@"^/chat(\s)+create", RegexOptions.IgnoreCase)]
    private static partial Regex CreateChatRegex();
}