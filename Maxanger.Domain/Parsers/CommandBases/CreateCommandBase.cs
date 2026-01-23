using Maxanger.Domain.Parsers.Abstract;
using Maxanger.Domain.Parsers.CommandMatchers.ChatMatcher;

namespace Maxanger.Domain.Parsers.CommandBases;

public class CreateCommandBase(IEnumerable<IChatCommandMatcher> matchers) : AbstractCommandBase<IChatCommandMatcher>(matchers)
{
    public override string Command => "/chat";
}