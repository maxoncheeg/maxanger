using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Interpreters.Abstract;

public interface ICommandExecutor
{
    public CommandAction Action { get; }
    
    public IExecutionResult Execute(IOperator @operator, IList<string>? arguments = null, IList<string>? modifiers = null);
}