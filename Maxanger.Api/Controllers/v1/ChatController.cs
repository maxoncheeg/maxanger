using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.Services.Messages.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class ChatController(IMediator mediator, IMessageService messageService) : AbstractController
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
    
    [HttpPost(MaxangerRoutes.Chat.Create)]
    public IActionResult CreateChat(string chatName, string username)
    {
        string command = $"/chat create {chatName}";
        

        
        return BaseResponse(StatusCodes.Status201Created);
    }
    
    [HttpPost(MaxangerRoutes.Chat.WhisperMessage)]
    public IActionResult WhisperMessage(int chatId, string username, string toUsername, string message)
    {

        
        return BaseResponse(StatusCodes.Status201Created);
    }
    
}