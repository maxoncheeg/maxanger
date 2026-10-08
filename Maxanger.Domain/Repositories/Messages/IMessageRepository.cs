using Maxanger.Domain.Entities.Messages;

namespace Maxanger.Domain.Repositories.Messages;

public interface IMessageRepository
{
    public Task<Message> GetMessageByIdAsync(int messageId, CancellationToken cancellationToken = default);
    public Task CreateMessageAsync(Message message, CancellationToken cancellationToken = default);
}