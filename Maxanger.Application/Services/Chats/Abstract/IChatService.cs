using Maxanger.Application.Models.Chats.Abstract;

namespace Maxanger.Application.Services.Chats.Abstract;

public interface IChatService
{
    public Task<IChatInfo> CreatePublicChatAsync(IList<long>? userIds = null, string name = "");
    public Task<IChatInfo> CreateDirectChatAsync(long withUserId);
    public Task<IChatInfo> CreatePrivateChatAsync(string name = "");
    public Task<IList<IChatInfo>> GetChatsAsync(int amount, int page, DateTime lastUpdatedTime);
}