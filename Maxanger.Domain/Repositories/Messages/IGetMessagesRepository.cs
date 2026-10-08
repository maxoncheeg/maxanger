using Maxanger.Domain.Entities.Messages;

namespace Maxanger.Domain.Repositories.Messages;

public interface IGetMessagesRepository
{
    public Task<IList<Message>> GetChatMessagesByUserIdAsync(long chatId, long userId, int skip, int take, CancellationToken cancellationToken);
    
}