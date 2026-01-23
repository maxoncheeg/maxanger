using Asp.Versioning;
using Maxanger.Application.CommandExecutors;
using Maxanger.Application.Hubs.Abstract;
using Maxanger.Domain.Interpreters;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Messengers;
using Maxanger.Domain.Messengers.Abstract;
using Maxanger.Domain.Parsers;
using Maxanger.Domain.Parsers.Abstract;
using Maxanger.Domain.Parsers.CommandBases;
using Maxanger.Domain.Parsers.CommandParseHandlers;
using Maxanger.Domain.Shells;
using Maxanger.Domain.Shells.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace Maxanger.Api.Controllers.v1.Hubs;

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