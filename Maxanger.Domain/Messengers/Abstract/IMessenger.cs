using Maxanger.Domain.Models.Chats.Abstract;

namespace Maxanger.Domain.Messengers.Abstract;

public interface IMessenger
{
    public event Action<long> NewChat; 
    public IList<IChat> Chats { get; }
    public void AddChat(IChat chat);
}