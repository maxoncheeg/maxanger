using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Chats;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.Hubs.Abstract;
using Maxanger.Application.Models.Chats.Abstract;
using Maxanger.Application.Services.Chats.Abstract;
using Maxanger.Application.Services.Messages.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Maxanger.Api.Controllers.v1.Hubs;

public class MaxangerHub(IMessageService messageService, IChatService chatService) : Hub, IChatHub
{
    [HubMethodName(MaxangerRoutes.MaxangerHub.SendMessage)]
    public async Task NewMessage([FromQuery] MessageOnSend messageOnSend)
    {
        var messages = await messageService.SendMessageAsync(messageOnSend);

        foreach (var message in messages.SentMessages)
        {
            foreach (var data in message.Metadata)
            {
                Console.WriteLine("\t\t" + data.Key + ": " + data.Value.ToString());
            }
        }

        //await Clients.All.SendAsync("messageReceived", username, message);
    }


    [HubMethodName(MaxangerRoutes.MaxangerHub.GetChats)]
    public async Task<IList<IChatInfo>> GetChatsAsync([FromQuery] GetChatsBody getChatsBody)
    {
        var chats = await chatService.GetChatsAsync(getChatsBody.PageSize, getChatsBody.Page,
            getChatsBody.LastUpdatedTime);
        
        Console.WriteLine(getChatsBody.Page + " " + getChatsBody.PageSize);
        
        return chats;
    }
    
    [HubMethodName(MaxangerRoutes.MaxangerHub.GetMessages)]
    public async Task<IList<IChatInfo>> GetMessagesAsync([FromQuery] GetChatsBody getChatsBody)
    {
        var chats = await chatService.GetChatsAsync(getChatsBody.PageSize, getChatsBody.Page,
            getChatsBody.LastUpdatedTime);
        
        Console.WriteLine(getChatsBody.Page + " " + getChatsBody.PageSize);
        
        return chats;
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