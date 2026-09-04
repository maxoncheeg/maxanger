using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Domain.Enums;

namespace Maxanger.Api.Models.Messages;

public class MessageOnSend : IMessageOnSend
{
    public long ChatId { get; set; }
    public long? ReplyToId { get; set; }
    public Dictionary<string, object>? Metadata { get; set; }
    public string Content { get; set; }
    public MessageType MessageType { get; set; }
}