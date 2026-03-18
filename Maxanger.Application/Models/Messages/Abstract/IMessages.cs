using Maxanger.Application.Models.Users.Abstract;

namespace Maxanger.Application.Models.Messages.Abstract;

public interface IMessages
{
    public IList<ISentMessage> SentMessages { get; }
    
    public IList<ISentMessage> Originals { get; }
    
    public IList<IMessageWriter> Users { get; }
}