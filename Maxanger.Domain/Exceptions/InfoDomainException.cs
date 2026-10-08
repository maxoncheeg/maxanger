namespace Maxanger.Domain.Exceptions;

public class InfoDomainException(List<string> messages) : Exception
{
    public IReadOnlyList<string> Messages { get; } = messages;
}