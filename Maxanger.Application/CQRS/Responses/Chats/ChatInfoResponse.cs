using Maxanger.Application.Models.Chats.Abstract;
using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.CQRS.Responses.Chats;

public class ChatInfoResponse : IChatInfo
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public ChatType Type { get; set; }
    public ILastChatMessage? LastMessage { get; set; }
}