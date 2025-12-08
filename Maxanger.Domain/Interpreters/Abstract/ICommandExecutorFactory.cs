using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Interpreters.Abstract;

public interface ICommandExecutorFactory
{
    public ICommandExecutor? GetExecutor(CommandAction action);
}