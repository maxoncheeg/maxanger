using Maxanger.Application.ContentHandlers.Receive.Abstract;
using Maxanger.Application.ContentHandlers.Send.Abstract;
using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Queries.ChatMembers;
using Maxanger.Application.CQRS.Queries.Messages;
using Maxanger.Application.CQRS.Queries.Users;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Application.Exceptions;
using Maxanger.Application.Models.Messages;
using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Application.Models.Users.Abstract;
using Maxanger.Application.Services.Messages.Abstract;
using Maxanger.Application.Services.Security.Abstract;
using Maxanger.Domain.Enums;
using MediatR;

namespace Maxanger.Application.Services.Messages;

public class MessageService(
    ISecurityService securityService,
    IMediator mediator,
    ISendContentHandlerFactory sendContentHandlerFactory,
    IReceiveContentHandlerFactory receiveContentHandlerFactory
)
    : IMessageService
{
    public async Task<IMessages> SendMessageAsync(IMessageOnSend messageOnSend)
    {
        var userId = securityService.GetCurrentUserIdAsync();

        if (userId == null)
            throw new UserIdNotFoundException();

        var chatMember = await mediator.Send(new GetChatMemberInfoByUserIdQuery(userId.Value, messageOnSend.ChatId));

        if (chatMember == null)
            throw new UserNotChatMemberException();

        switch (chatMember.Status)
        {
            case MemberStatus.Muted:
                throw new MutedChatMemberException();
            case MemberStatus.Banned:
                throw new BannedChatMemberException();
        }

        var textPayload = await sendContentHandlerFactory.GetHandler(messageOnSend.MessageType)
            .HandleAsync(messageOnSend.Payload);

        var response = await mediator.Send(new SendMessageCommand(userId.Value, messageOnSend.ChatId, textPayload,
            messageOnSend.MessageType, messageOnSend.ReplyToId));

        if (response == null)
            throw new MessageNotSendException();

        var messages = new Models.Messages.Messages();

        if (response.ReplyToId.HasValue)
        {
            var replyMessage = (await mediator.Send(new GetMessagesByIdsQuery([response.ReplyToId.Value])))
                .FirstOrDefault();

            if (replyMessage != null)
            {
                var replyJsonPayload = await receiveContentHandlerFactory.GetHandler(replyMessage.Type)
                    .HandleAsync(replyMessage.Payload);

                messages.Originals =
                [
                    new SentMessage
                    {
                        Id = replyMessage.Id,
                        FromId = replyMessage.FromId,
                        ReplyToId = replyMessage.ReplyToId,
                        CreatedAt = replyMessage.CreatedAt,
                        UpdatedAt = replyMessage.UpdatedAt,
                        ChatId = replyMessage.ChatId,
                        Payload = replyJsonPayload
                    }
                ];
            }
        }

        var jsonPayload = await receiveContentHandlerFactory.GetHandler(messageOnSend.MessageType)
            .HandleAsync(response.Payload);

        messages.SentMessages =
        [
            new SentMessage
            {
                Id = response.Id,
                FromId = response.FromId,
                ReplyToId = response.ReplyToId,
                CreatedAt = response.CreatedAt,
                UpdatedAt = response.UpdatedAt,
                ChatId = messageOnSend.ChatId,
                Payload = jsonPayload
            }
        ];

        return messages;
    }

    public async Task<IMessages> GetChatMessagesAsync(long chatId, int amount = 50, int page = 0)
    {
        var userId = securityService.GetCurrentUserIdAsync();

        if (userId == null)
            throw new UserIdNotFoundException();

        var chatMember = await mediator.Send(new GetChatMemberInfoByUserIdQuery(userId.Value, chatId));

        if (chatMember == null)
            throw new UserNotChatMemberException();

        if (chatMember.Status == MemberStatus.Banned)
            throw new BannedChatMemberException();

        var messages = await mediator.Send(new GetMessagesQuery(chatId, userId.Value)
        {
            Page = page,
            Take = amount
        });

        if (messages.Count == 0)
        {
            return new Models.Messages.Messages();
        }
        
        List<ISentMessage> sentMessages = new List<ISentMessage>();
        
        foreach (var message in messages)
        {
            // todo: запускать таски отдельно Task.WaitAll
            var payload = await receiveContentHandlerFactory.GetHandler(message.Type)
                .HandleAsync(message.Payload);

            sentMessages.Add(new SentMessage
            {
                Id = message.Id,
                FromId = message.FromId,
                ReplyToId = message.ReplyToId,
                CreatedAt = message.CreatedAt,
                UpdatedAt = message.UpdatedAt,
                ChatId = message.ChatId,
                Payload = payload
            });
        }

        var existingMessageIds = new HashSet<long>(messages.Select(m => m.Id));
        
        var originalIds = messages
            .Where(m => m.ReplyToId.HasValue)
            .Select(m => m.ReplyToId!.Value)
            .Where(id => !existingMessageIds.Contains(id))
            .Distinct()
            .ToList();

        var originalsResponse = await mediator.Send(new GetMessagesByIdsQuery(originalIds));
        
        List<ISentMessage> originals = new List<ISentMessage>();
        
        foreach (var message in originalsResponse)
        {
            var payload = await receiveContentHandlerFactory.GetHandler(message.Type)
                .HandleAsync(message.Payload);

            originals.Add(new SentMessage
            {
                Id = message.Id,
                FromId = message.FromId,
                ReplyToId = message.ReplyToId,
                CreatedAt = message.CreatedAt,
                UpdatedAt = message.UpdatedAt,
                ChatId = message.ChatId,
                Payload = payload
            });
        }
        
        var userIds = sentMessages
            .Where(m => m.FromId != userId)
            .Select(m => m.FromId)
            .Union(originals.Where(o => o.FromId != userId).Select(o => o.FromId))
            .ToList();

        List<IMessageWriter> users = [..await mediator.Send(new GetMessageWritersByIdsQuery(userIds))];

        return new Models.Messages.Messages
        {
            SentMessages = sentMessages,
            Originals = originals.Count > 0 ? originals : null,
            Users = users
        };
    }
}