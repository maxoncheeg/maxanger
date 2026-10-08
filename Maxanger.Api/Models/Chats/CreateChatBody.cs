using Maxanger.Domain.Enums;

namespace Maxanger.Api.Models.Chats;

public class CreateChatBody
{
    public required string ChatName { get; set; }
    public Dictionary<long, MemberRole>? Users { get; set; }
}