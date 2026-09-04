using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Chats.Abstract;

public interface IChatInfo
{
    public long Id { get; }
    public string? Name { get; }
    public ChatType Type { get; }
    public ILastChatMessage? LastMessage { get; }
}