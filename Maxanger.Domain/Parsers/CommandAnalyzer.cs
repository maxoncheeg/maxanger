using Maxanger.Domain.Enums;
using Maxanger.Domain.Parsers.Abstract;

namespace Maxanger.Domain.Parsers;

public class CommandAnalyzer : ICommandAnalyzer
{
    private readonly Dictionary<string, ICommandBase> _commands;

    public CommandAnalyzer(IEnumerable<ICommandBase> commands)
    {
        _commands = commands.ToDictionary(
            command => command.Command,
            command => command,
            StringComparer.OrdinalIgnoreCase);
    }

    public CommandAction Analyze(string command)
    {
        var commandTokens = command.Trim().Split();

        if (commandTokens.Length < 2) return CommandAction.Error;

        var commandStart = commandTokens[..2];
        var commandBase = _commands.GetValueOrDefault(commandStart[0]);

        if (commandBase == null) return CommandAction.Error;

        return commandBase.SubcommandMatcher(commandStart[1])
            ? commandBase.Action
            : CommandAction.Error;
    }
}