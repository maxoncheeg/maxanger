using System.Text.Json.Serialization;
using Maxanger.Application.Models.Messages.Abstract;
using Maxanger.Application.Models.Users.Abstract;

namespace Maxanger.Application.Models.Messages;

public class Messages : IMessages
{
    public IList<ISentMessage> SentMessages { get; set; } = [];

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<ISentMessage>? Originals { get; set; } = null;

    public IList<IMessageWriter> Users { get; set; } = [];
}