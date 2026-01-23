namespace Maxanger.Application.Hubs.Abstract;

public interface IChatHub
{
    public Task NotifyCallerAsync(string method, object? message);
    public Task NotifyAllClientsAsync(string method, object? message);
}