using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Services.Messages;

public interface ISendMessageService
{
    public Task<Message> SendMessageAsync(long userId, long chatId, string content, MessageType messageType,
        Dictionary<string, object>? metadata, long? replyToId = null, CancellationToken cancellationToken = default);
}