using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Chats;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.Hubs.Abstract;
using Maxanger.Application.Models.Chats.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Maxanger.Api.Controllers.v1.Hubs;

public class MaxangerHub : Hub, IChatHub
{
    [HubMethodName(MaxangerRoutes.MaxangerHub.SendMessage)]
    public async Task NewMessage([FromQuery] MessageOnSend messageOnSend)
    {

        //await Clients.All.SendAsync("messageReceived", username, message);
    }


    [HubMethodName(MaxangerRoutes.MaxangerHub.GetChats)]
    public async Task<IList<IChatInfo>> GetChatsAsync([FromQuery] GetChatsBody getChatsBody)
    {
        return null;
    }
    
    [HubMethodName(MaxangerRoutes.MaxangerHub.GetMessages)]
    public async Task<IList<IChatInfo>> GetMessagesAsync([FromQuery] GetChatsBody getChatsBody)
    {
        return null;
    }

    [HubMethodName("executeCommand")]
    public async Task ExecuteCommandAsync(string @operator, string command)
    {
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