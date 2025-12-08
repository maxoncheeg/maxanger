using Maxanger.Domain.Models.Chats.Abstract;

namespace Maxanger.Application.Observers;

public interface IChatObserver
{
    public void SetChat(IChat chat);
    
}