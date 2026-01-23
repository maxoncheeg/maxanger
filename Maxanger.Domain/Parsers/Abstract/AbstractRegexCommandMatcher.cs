using System.Text.RegularExpressions;
using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Parsers.Abstract;

public abstract class AbstractRegexCommandMatcher(CommandAction action) : ICommandMatcher
{
    public CommandAction Action { get; } = action;
    
    public bool Match(string command)
    {
        return GetMatchRegex().IsMatch(command);
    }
    
    protected abstract Regex GetMatchRegex(); 
}