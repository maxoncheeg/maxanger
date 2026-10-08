using Maxanger.Domain.Parsers.Abstract;
using Maxanger.Domain.Parsers.CommandMatchers.MessageMatcher;

namespace Maxanger.Domain.Parsers.CommandBases;

public class MessageCommandBase(IEnumerable<IMessageCommandMatcher> matchers) : AbstractCommandBase<IMessageCommandMatcher>(matchers)
{
    public override string Command => "/m";
}