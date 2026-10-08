using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Repositories.Chats;

namespace Maxanger.Domain.Services.Chats;

public class ChatService(
    IChatRepository chatRepository,
    IMessageContentEncryptor contentEncryptor,
    IUnitOfWork unitOfWork) : IChatService
{
    public async Task<bool> IsUserInChatAsync(long userId, long chatId, CancellationToken cancellationToken = default)
    {
        return await chatRepository.IsUserInChatAsync(userId, chatId, cancellationToken);
    }

    public async Task<Chat> CreatePublicChatAsync(string chatName, long userId,
        IDictionary<long, MemberRole>? users = null,
        CancellationToken cancellationToken = default)
    {
        var chat = Chat.Create(ChatType.Public, chatName);

        chat.AddMember(userId, MemberRole.Creator, MemberStatus.None);

        if (users != null)
            foreach (var user in users)
                chat.AddMember(user.Key, user.Value, MemberStatus.None);

        chat.SendMessage(userId, contentEncryptor.Encrypt("CHAT_CREATION"), MessageType.System,
            new Dictionary<string, object> { { "chatName", chatName } });

        chatRepository.CreateChat(chat);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return chat;
    }
}