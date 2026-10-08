using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Repositories.Chats;
using Maxanger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Repositories.Chats;

public class ChatRepository(ApplicationDbContext context) : IChatRepository
{
    public async Task<bool> IsUserInChatAsync(long userId, long chatId, CancellationToken cancellationToken)
    {
        return await context.ChatMembers.Where(c => c.UserId == userId && c.ChatId == chatId).AnyAsync(cancellationToken);
    }

    public async Task<Chat> GetChatByIdAsync(long chatId, CancellationToken cancellationToken)
    {
        return await (from chats in context.Chats where chats.Id == chatId select chats).SingleAsync(cancellationToken);
    }

    public void CreateChat(Chat chat)
    {
        context.Add(chat);
    }
}