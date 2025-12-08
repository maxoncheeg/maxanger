namespace Maxanger.Domain.Models.Shells.Abstract;

public interface ICommandShellResult
{
    public object? Data { get; }
    public string? Message { get; }
}