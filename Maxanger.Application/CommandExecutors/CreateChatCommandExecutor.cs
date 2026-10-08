using Maxanger.Domain.Enums;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Models;
using Maxanger.Domain.Models.Interpreters.Abstract;

namespace Maxanger.Application.CommandExecutors;

public class CreateChatCommandExecutor() : ICommandExecutor
{
    public CommandAction Action => CommandAction.ChatCreate;

    public async Task<IExecutionResult> ExecuteAsync(IOperator @operator, IList<string>? arguments = null, IEnvironments? environments = null, IList<string>? modifiers = null)
    {

        return null;
    }
}