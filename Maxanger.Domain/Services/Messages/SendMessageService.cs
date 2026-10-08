using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Exceptions;
using Maxanger.Domain.Repositories.Messages;
using Maxanger.Domain.Services.Chats;

namespace Maxanger.Domain.Services.Messages;

public class SendMessageService(IMessageContentEncryptor messageContentEncryptor, IChatService chatService, IMessageRepository repository, IUnitOfWork unitOfWork) : ISendMessageService
{
    public async Task<Message> SendMessageAsync(long userId, long chatId, string content, MessageType messageType, Dictionary<string, object>? metadata,
        long? replyToId = null, CancellationToken cancellationToken = default)
    {
        if (!await chatService.IsUserInChatAsync(userId, chatId, cancellationToken))
            throw new DomainException("USER_NOT_IN_CHAT", "Пользователь не состоит в чате");

        var encryptedContent = messageContentEncryptor.Encrypt(content);
        var message = Message.Create(messageType, encryptedContent, userId, chatId, metadata, replyToId);
        
        await repository.CreateMessageAsync(message, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return message;
    }
}