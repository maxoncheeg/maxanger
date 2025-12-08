using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Commands.Abstract;

namespace Maxanger.Domain.Models.Commands;

public class ParsedCommand(CommandAction action, IList<string>? arguments = null, IList<string>? modifiers = null) : IParsedCommand
{
    public CommandAction Action => action;
    public IList<string>? Arguments => arguments;
    public IList<string>? Modifiers => modifiers;
}