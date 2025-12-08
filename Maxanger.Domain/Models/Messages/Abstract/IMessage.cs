using Maxanger.Domain.Models.Chats.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Models.Messages.Abstract;

public interface IMessage
{
    public long Id { get; set; }
    public string Text { get; set; }
    public IChat Chat { get; set; } 
    public IOperator From { get; set; }
    public DateTime Date { get; set; }
    public IOperator? WhisperTo { get; set; }
}