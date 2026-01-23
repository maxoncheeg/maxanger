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
        var trimmedCommand = command.Trim();
        var commandTokens = trimmedCommand.Split();

        if (commandTokens.Length < 2) return CommandAction.Error;

        var commandBase = _commands.GetValueOrDefault(commandTokens[0]);

        if (commandBase == null) return CommandAction.Error;

        return commandBase.MatchCommand(trimmedCommand);
    }
}