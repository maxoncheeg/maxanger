using Maxanger.Domain.Enums;
using Maxanger.Domain.Models;
using Maxanger.Domain.Models.Interpreters.Abstract;

namespace Maxanger.Domain.Interpreters.Abstract;

public interface ICommandExecutor
{
    public CommandAction Action { get; }
    
    public Task<IExecutionResult> ExecuteAsync(IOperator @operator, IList<string>? arguments = null, IEnvironments? environments = null, IList<string>? modifiers = null);
}