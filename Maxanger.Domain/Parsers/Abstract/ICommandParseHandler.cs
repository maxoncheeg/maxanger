using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandParseHandler
{
    public CommandAction Action { get; }
    
    public IParseResult Parse(string command);
}