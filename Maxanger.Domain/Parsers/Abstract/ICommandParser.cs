using Maxanger.Domain.Models.Parsers.Abstract;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandParser
{
    public IParseResult Parse(string command);
}