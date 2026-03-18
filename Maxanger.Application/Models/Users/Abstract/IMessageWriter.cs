namespace Maxanger.Application.Models.Users.Abstract;

public interface IMessageWriter
{
    public long Id { get; }
    public string Username { get; }
}