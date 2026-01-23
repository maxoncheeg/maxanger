using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandBase
{
    public string Command { get; }
    public CommandAction MatchCommand(string command);
}