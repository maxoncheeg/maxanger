using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Services.Chats;

public interface IChatService
{
    public Task<bool> IsUserInChatAsync(long userId, long chatId, CancellationToken cancellationToken = default);
    public Task<Chat> CreatePublicChatAsync(string chatName, long userId, IDictionary<long, MemberRole>? users = null, CancellationToken cancellationToken = default);
}