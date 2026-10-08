using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Repositories.Messages;
using Maxanger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Repositories.Messages;

public class MessageRepository(ApplicationDbContext context) : IMessageRepository
{
    public async Task<Message> GetMessageByIdAsync(int messageId, CancellationToken cancellationToken = default)
    {
        return await context.Messages.SingleAsync(message => message.Id == messageId, cancellationToken);
    }

    public async Task CreateMessageAsync(Message message, CancellationToken cancellationToken = default)
    {
        await context.CreateAsync(message);
    }
}