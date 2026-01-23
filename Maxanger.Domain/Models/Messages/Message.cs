using Maxanger.Domain.Models.Chats.Abstract;
using Maxanger.Domain.Models.Messages.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Models.Messages;

public class Message : IMessage
{
    public long Id { get; set; }
    public required string Text { get; set; }
    public required IChat Chat { get; set; }
    public required IOperator From { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public IOperator? WhisperTo { get; set; }
    public bool RolePlay { get; set; }
}