using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Models.Commands.Abstract;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Interpreters;

public class CommandInterpreter(ICommandExecutorFactory commandExecutorFactory) : ICommandInterpreter
{
    public async Task<object?> ExecuteAsync(IOperator @operator, IParsedCommand command, IEnvironments? environments)
    {
        var commandExecutor = commandExecutorFactory.GetExecutor(command.Action);
        
        if(commandExecutor == null)
            throw new Exception("Command executor not found");
        
        return await commandExecutor.ExecuteAsync(@operator, command.Arguments, environments, command.Modifiers);
    }
}