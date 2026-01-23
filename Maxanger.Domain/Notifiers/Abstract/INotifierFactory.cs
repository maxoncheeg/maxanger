using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Notifiers.Abstract;

public interface INotifierFactory
{
    public INotifier? GetNotifier(CommandAction action);
}