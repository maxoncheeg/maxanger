using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Chats.Abstract;

public interface IChatInfo
{
    public long Id { get; }
    public string? Name { get; }
    public ChatType Type { get; }
    public LastChatMessageDto? LastMessage { get; }
}