using Maxanger.Domain.Models.Commands.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Interpreters.Abstract;

public interface ICommandInterpreter
{
    public object? Execute(IOperator @operator, IParsedCommand command);
}