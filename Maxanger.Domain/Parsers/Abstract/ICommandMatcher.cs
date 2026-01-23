using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandMatcher
{
    public CommandAction Action { get; }
    public bool Match(string command);
}