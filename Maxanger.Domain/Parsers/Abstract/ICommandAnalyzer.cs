using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public interface ICommandAnalyzer
{
    public CommandAction Analyze(string command);
}