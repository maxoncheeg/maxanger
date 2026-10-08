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
        return await context.Messages.OrderByDescending(m => m.CreatedAt)
            .Where(c => c.Chat.ChatMembers.Any(m => m.ChatId == chatId && m.UserId == userId))
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
}