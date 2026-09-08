using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Repositories.Messages;
using Maxanger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Repositories.Messages;

public class GetMessagesRepository(ApplicationDbContext context) : IGetMessagesRepository
{
    public async Task<IList<Message>> GetChatMessagesByUserIdAsync(long chatId, long userId, int skip, int take,
        CancellationToken cancellationToken)
    {
        return await (from message in context.Messages
            where message.ChatId == chatId && message.FromId == userId
            orderby message.CreatedAt
            select message)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
}