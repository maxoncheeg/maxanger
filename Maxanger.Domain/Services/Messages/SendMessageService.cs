using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Enums;
using Maxanger.Domain.Repositories.Messages;

namespace Maxanger.Domain.Services.Messages;

public class SendMessageService(IMessageContentEncryptor messageContentEncryptor, IMessageRepository repository, IUnitOfWork unitOfWork) : ISendMessageService
{
    public async Task<Message> SendMessageAsync(long userId, long chatId, string content, MessageType messageType, Dictionary<string, object>? metadata,
        long? replyToId = null, CancellationToken cancellationToken = default)
    {
        var encryptedContent = messageContentEncryptor.Encrypt(content);
        var message = Message.Create(messageType, encryptedContent, userId, chatId, metadata, replyToId);
        
        await repository.CreateMessageAsync(message, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return message;
    }
}