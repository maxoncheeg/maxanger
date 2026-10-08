using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Exceptions;
using Maxanger.Domain.Repositories.Messages;
using Maxanger.Domain.Services.Chats;

namespace Maxanger.Domain.Services.Messages;

public class GetMessagesService(
    IGetMessagesRepository getMessagesRepository,
    IChatService chatService,
    IMessageContentEncryptor contentEncryptor)
    : IGetMessagesService
{
    public async Task<IList<Message>> GetMessagesAsync(long chatId, long userId, int skip, int take,
        CancellationToken cancellationToken)
    {
        if (!await chatService.IsUserInChatAsync(userId, chatId, cancellationToken))
            throw new DomainException("USER_NOT_IN_CHAT", "Пользователь не состоит в чате");

        var messages =
            await getMessagesRepository.GetChatMessagesByUserIdAsync(chatId, userId, skip, take, cancellationToken);

        return
        [
            .. messages.Select(message => Message.Create(message.Id, message.Type,
                contentEncryptor.Decrypt(message.Content), message.FromId, message.ChatId, message.Metadata,
                message.ReplyToMessageId))
        ];
    }
}