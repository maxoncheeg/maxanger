namespace Maxanger.Application.CQRS;

public record PagedQuery
{
    public int Take { get; init; } = 50;
    public int Page { get; init; } = 0;
}