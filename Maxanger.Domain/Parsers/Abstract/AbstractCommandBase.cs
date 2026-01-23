using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public abstract class AbstractCommandBase<T>(IEnumerable<T> matchers) : ICommandBase
    where T : ICommandMatcher
{
    private readonly IReadOnlyList<ICommandMatcher> _commandMatchers = [..matchers];

    public abstract string Command { get; }


    public CommandAction MatchCommand(string command)
    {
        return (from matcher in _commandMatchers where matcher.Match(command) select matcher.Action).FirstOrDefault();
    }
}