using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class ChatController(IMediator mediator) : AbstractController
{

    
    [HttpGet(MaxangerRoutes.Chat.Base)]
    public IActionResult Get(int chatId, string username)
    {

        
        return BaseResponse(StatusCodes.Status200OK, "");
    }

    [HttpPost(MaxangerRoutes.Chat.SendMessage)]
    public IActionResult SendMessage(int chatId, string username, string message)
    {
        string command = $"/m {chatId} {message}";
        

        return BaseResponse(StatusCodes.Status201Created);
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