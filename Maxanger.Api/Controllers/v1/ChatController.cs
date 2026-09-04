using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.Services.Chats.Abstract;
using Maxanger.Application.Services.Messages.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class ChatController(IChatService chatService, IMessageService messageService) : AbstractController
{
    
    [HttpPost(MaxangerRoutes.Chat.SendMessage)]
    public async Task<IActionResult> SendMessage([FromBody]MessageOnSend message)
    {
        var messages = await messageService.SendMessageAsync(message);

        return StatusCode(StatusCodes.Status201Created, messages);
    }
    
    [HttpGet(MaxangerRoutes.Chat.Base)]
    public async Task<IActionResult> SendMessage(long chatId, int take = 50, int page = 0)
    {
        var messages = await messageService.GetChatMessagesAsync(chatId, take, page);

        return StatusCode(StatusCodes.Status201Created, messages);
    }
    
    [HttpPost(MaxangerRoutes.Chat.GetChats)]
    public async Task<IActionResult> CreateChat(int take = 50, int page = 0)
    {
        var messages = await chatService.GetChatsAsync(take, page, DateTime.UtcNow - TimeSpan.FromDays(365));

        return StatusCode(StatusCodes.Status201Created, messages);
    }
    
    [HttpPost(MaxangerRoutes.Chat.WhisperMessage)]
    public IActionResult WhisperMessage(int chatId, string username, string toUsername, string message)
    {

        
        return BaseResponse(StatusCodes.Status201Created);
    }
    
}