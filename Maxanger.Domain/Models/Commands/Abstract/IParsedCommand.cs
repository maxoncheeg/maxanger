using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Models.Commands.Abstract;

public interface IParsedCommand
{
    public CommandAction Action { get; }
    public IList<string>? Arguments { get; }
    public IList<string>? Modifiers { get; }
}