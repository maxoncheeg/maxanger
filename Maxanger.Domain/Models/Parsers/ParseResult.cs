using Maxanger.Domain.Models.Commands.Abstract;
using Maxanger.Domain.Models.Parsers.Abstract;

namespace Maxanger.Domain.Models.Parsers;

public class ParseResult(IParsedCommand parsedCommand) : IParseResult
{
    public IParsedCommand Command => parsedCommand;
    public string? Error { get; init; }
}