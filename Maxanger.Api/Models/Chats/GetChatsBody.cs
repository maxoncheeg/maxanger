namespace Maxanger.Api.Models.Chats;

public record GetChatsBody
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public DateTime LastUpdatedTime { get; init; } = DateTime.UtcNow;
}