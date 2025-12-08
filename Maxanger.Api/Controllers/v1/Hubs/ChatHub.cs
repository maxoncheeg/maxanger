using Asp.Versioning;
using Maxanger.Application.CommandExecutors;
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
public class ChatHub : Hub
{
    public ChatHub()
    {
        
    }
    
    [HubMethodName("newMessage")]
    public async Task NewMessage(string username, string message)
    {
        Console.WriteLine($"{username} : {message}");
        await Clients.All.SendAsync("messageReceived", username, message);
    }
}