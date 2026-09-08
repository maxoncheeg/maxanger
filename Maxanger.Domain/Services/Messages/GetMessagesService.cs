using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Repositories.Messages;

namespace Maxanger.Domain.Services.Messages;

public class GetMessagesService(IGetMessagesRepository getMessagesRepository, IMessageContentEncryptor contentEncryptor)
    : IGetMessagesService
{
    public async Task<IList<Message>> GetMessagesAsync(long chatId, long userId, int skip, int take,
        CancellationToken cancellationToken)
    {
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