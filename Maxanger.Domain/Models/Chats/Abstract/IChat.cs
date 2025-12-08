using Maxanger.Domain.Models.Messages.Abstract;

namespace Maxanger.Domain.Models.Chats.Abstract;

public interface IChat
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IList<IMessage> Messages { get; set; }
}