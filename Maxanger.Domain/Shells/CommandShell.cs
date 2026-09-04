using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Models;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Parsers.Abstract;
using Maxanger.Domain.Shells.Abstract;

namespace Maxanger.Domain.Shells;

public class CommandShell(ICommandParser parser, ICommandInterpreter interpreter) : ICommandShell
{
    public object? Invoke(IOperator @operator, string command, IEnvironments? environments = null)
    {
        var parseResult = parser.Parse(command);
        
        // todo: обработки ошибок
        
        return interpreter.ExecuteAsync(@operator, parseResult.Command, environments);
    }
}