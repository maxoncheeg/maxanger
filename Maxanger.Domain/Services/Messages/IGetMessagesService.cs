using Maxanger.Domain.Entities.Messages;

namespace Maxanger.Domain.Services.Messages;

public interface IGetMessagesService
{
    public Task<IList<Message>> GetMessagesAsync(long chatId, long userId, int skip, int take, CancellationToken cancellationToken);
}