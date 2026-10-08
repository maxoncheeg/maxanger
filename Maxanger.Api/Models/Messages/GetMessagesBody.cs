namespace Maxanger.Api.Models.Messages;

public class GetMessagesBody
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public DateTime LastUpdatedTime { get; init; } = DateTime.UtcNow;
}