using Maxanger.Application.CQRS.Queries.Chats;
using Maxanger.Application.Exceptions;
using Maxanger.Application.Models.Chats.Abstract;
using Maxanger.Application.Services.Chats.Abstract;
using Maxanger.Application.Services.Messages.Abstract;
using Maxanger.Application.Services.Security.Abstract;
using MediatR;

namespace Maxanger.Application.Services.Chats;

public class ChatService(ISecurityService securityService, IMediator mediator, IContentEncryptor encryptor)
    : IChatService
{
    public Task<IChatInfo> CreatePublicChatAsync(IList<long>? userIds = null, string name = "")
    {
        throw new NotImplementedException();
    }

    public Task<IChatInfo> CreateDirectChatAsync(long withUserId)
    {
        throw new NotImplementedException();
    }

    public Task<IChatInfo> CreatePrivateChatAsync(string name = "")
    {
        throw new NotImplementedException();
    }

    public async Task<IList<IChatInfo>> GetChatsAsync(int amount, int page, DateTime lastUpdatedTime)
    {
        long? userId = securityService.GetCurrentUserId();

        if (!userId.HasValue)
            throw new UserNotFoundException();

        var response = await mediator.Send(new GetChatsInfoQuery(userId.Value, lastUpdatedTime) { Take = amount, Page = page });

        foreach (var chatInfo in response)
            if (chatInfo.LastMessage != null)
                chatInfo.LastMessage.Content = encryptor.Decrypt(chatInfo.LastMessage.Content);

        return [..response];
    }
}