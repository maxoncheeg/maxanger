using System.Text.Json;
using Maxanger.Domain.Enums;

namespace Maxanger.Application.Models.Messages.Abstract;

public interface IMessageOnSend
{
    public long ChatId { get; set; }
    public long? ReplyToId { get; set; }
    public JsonElement Payload { get; set; }
    public MessageType MessageType { get; set; }
}