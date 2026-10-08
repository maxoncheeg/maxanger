using Maxanger.Domain.Entities.Chats;

namespace Maxanger.Domain.Repositories.Chats;

public interface IChatRepository
{
    public Task<bool> IsUserInChatAsync(long userId, long chatId, CancellationToken cancellationToken);
    public Task<Chat> GetChatByIdAsync(long chatId, CancellationToken cancellationToken);
    public void CreateChat(Chat chat);
}