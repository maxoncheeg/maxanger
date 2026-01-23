using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Shells.Abstract;

public interface ICommandShell
{
    public object? Invoke(IOperator @operator, string command, IEnvironments? environments = null);
}