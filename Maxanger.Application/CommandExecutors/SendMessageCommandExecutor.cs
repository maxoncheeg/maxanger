using Maxanger.Domain.Enums;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Models;
using Maxanger.Domain.Models.Interpreters;
using Maxanger.Domain.Models.Interpreters.Abstract;

namespace Maxanger.Application.CommandExecutors;

public class SendMessageCommandExecutor() : ICommandExecutor
{
    public CommandAction Action => CommandAction.SendMessage;

    public async Task<IExecutionResult> ExecuteAsync(IOperator @operator, IList<string>? arguments = null,
        IEnvironments? environments = null, IList<string>? modifiers = null)
    {
        return new ExecutionResult() { };
    }
}