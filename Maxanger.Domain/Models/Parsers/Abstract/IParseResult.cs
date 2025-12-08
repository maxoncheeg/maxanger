using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Commands.Abstract;

namespace Maxanger.Domain.Models.Parsers.Abstract;

public interface IParseResult
{
    public IParsedCommand Command { get; }
    public string? Error { get; }
}