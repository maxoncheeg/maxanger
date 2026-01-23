using Maxanger.Domain.Models.Commands.Abstract;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Interpreters.Abstract;

public interface ICommandInterpreter
{
    public Task<object?> ExecuteAsync(IOperator @operator, IParsedCommand command, IEnvironments? environments = null);
}