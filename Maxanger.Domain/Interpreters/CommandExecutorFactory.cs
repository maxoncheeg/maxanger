using Maxanger.Domain.Enums;
using Maxanger.Domain.Interpreters.Abstract;

namespace Maxanger.Domain.Interpreters;

public class CommandExecutorFactory : ICommandExecutorFactory
{
    private readonly Dictionary<CommandAction, ICommandExecutor> _executors;

    public CommandExecutorFactory(IEnumerable<ICommandExecutor> executors)
    {
        _executors = executors.ToDictionary(parser => parser.Action, parser => parser);
    }

    public ICommandExecutor? GetExecutor(CommandAction action) => _executors.GetValueOrDefault(action);
}