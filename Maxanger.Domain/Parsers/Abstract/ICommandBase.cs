using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandBase
{
    public string Command { get; }
    public Predicate<string> SubcommandMatcher { get; }
    public CommandAction Action { get; }
}