using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Models.Commands.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Interpreters;

public class CommandInterpreter(ICommandExecutorFactory commandExecutorFactory) : ICommandInterpreter
{
    public object? Execute(IOperator @operator, IParsedCommand command)
    {
        var commandExecutor = commandExecutorFactory.GetExecutor(command.Action);
        
        if(commandExecutor == null)
            throw new Exception("Command executor not found");
        
        return commandExecutor.Execute(@operator, command.Arguments, command.Modifiers);
    }
}