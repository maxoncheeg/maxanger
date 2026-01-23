using Maxanger.Domain.Enums;
using Maxanger.Domain.Notifiers.Abstract;

namespace Maxanger.Domain.Notifiers;

public class NotifierFactory : INotifierFactory
{
    private readonly Dictionary<CommandAction, INotifier> _notifiers;

    public NotifierFactory(IEnumerable<INotifier> notifiers)
    {
        _notifiers = notifiers.ToDictionary(notifier => notifier.Action, notifier => notifier);
    }

    public INotifier? GetNotifier(CommandAction action) => _notifiers.GetValueOrDefault(action);
}