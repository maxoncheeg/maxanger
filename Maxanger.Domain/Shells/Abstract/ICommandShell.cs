using Maxanger.Domain.Models;
using Maxanger.Domain.Models.Interpreters.Abstract;

namespace Maxanger.Domain.Shells.Abstract;

public interface ICommandShell
{
    public object? Invoke(IOperator @operator, string command, IEnvironments? environments = null);
}