using Maxanger.Domain.Models.Chats.Abstract;
using Maxanger.Domain.Models.Messages.Abstract;

namespace Maxanger.Domain.Models.Chats;

public class Chat : IChat
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<IMessage> Messages { get; set; } = [];
}