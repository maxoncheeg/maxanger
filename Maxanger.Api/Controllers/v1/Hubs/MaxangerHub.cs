using Asp.Versioning;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.Hubs.Abstract;
using Maxanger.Application.Services.Messages.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Maxanger.Api.Controllers.v1.Hubs;

[ApiVersion(1)]
public class MaxangerHub(IMessageService messageService) : Hub, IChatHub
{
    
    [HubMethodName(MaxangerRoutes.MaxangerHub.SendMessage)]
    public async Task NewMessage([FromQuery] MessageOnSend messageOnSend)
    {
        var messages = await messageService.SendMessageAsync(messageOnSend);
        Console.WriteLine("\nMESSAGE: " + messages.SentMessages.First().Payload.GetRawText() ?? "aboba");
        Console.WriteLine("\nREPLY: " + messages.Originals?.First().Payload.GetRawText() ?? "aboba");
        
        //await Clients.All.SendAsync("messageReceived", username, message);
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