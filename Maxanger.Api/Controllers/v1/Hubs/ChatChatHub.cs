using System.Text.Json;
using Asp.Versioning;
using Maxanger.Application.Hubs.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace Maxanger.Api.Controllers.v1.Hubs;

public class NewMessageRequest
{
    public long ChatId { get; set; }
    public long UserId { get; set; }
    public string Type { get; set; } = null!;
    public JsonElement Payload { get; set; }
}

[ApiVersion(1)]
public class ChatChatHub : Hub, IChatHub
{
    public ChatChatHub()
    {
        
    }
    
    [HubMethodName("newMessage")]
    public async Task NewMessage(string username, string message)
    {
        Console.WriteLine($"{username} : {message}");
        await Clients.All.SendAsync("messageReceived", username, message);
    }
    
    [HubMethodName("executeCommand")]
    public async Task ExecuteCommandAsync(string @operator, string command)
    {
        Console.WriteLine($"{@operator} : {command}");
        // await Clients.All.SendAsync("messageReceived", username, message);
    }

    public async Task NotifyCallerAsync(string method, object? message)
    {
        await Clients.Caller.SendAsync(method, message);
    }

    public async Task NotifyAllClientsAsync(string method, object? message)
    {
        await Clients.All.SendAsync(method, message);
    }
}