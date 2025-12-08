using Maxanger.Domain.Messengers.Abstract;
using Maxanger.Domain.Models.Chats.Abstract;

namespace Maxanger.Domain.Messengers;

public class Messenger : IMessenger
{
    private readonly List<IChat> _chats = new List<IChat>();
    public event Action<long>? NewChat;
    public IList<IChat> Chats => _chats;

    public void AddChat(IChat chat)
    {
        _chats.Add(chat);
        NewChat?.Invoke(chat.Id);
    }
}