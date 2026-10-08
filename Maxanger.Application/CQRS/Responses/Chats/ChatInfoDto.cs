using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Application.Models.Chats.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.CQRS.Responses.Chats;

public class ChatInfoDto : IChatInfo
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public ChatType Type { get; set; }
    public LastChatMessageDto? LastMessage { get; set; }
}