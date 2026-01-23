using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Notifiers.Abstract;

public interface INotifier
{
    public CommandAction Action { get; }
    public Task NotifyAsync(string? message = null);
}