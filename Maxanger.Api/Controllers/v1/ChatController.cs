using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Chats;
using Maxanger.Application.CQRS.Commands.Chats;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class ChatController(IMediator mediator) : AbstractController
{
    [HttpPost(MaxangerRoutes.Chats.Base)]
    public async Task<IActionResult> SendMessage([FromBody] CreateChatBody body)
    {
        long userId = 2;

        var response = await mediator.Send(new CreatePublicChatCommand(body.ChatName, userId) { Users = body.Users });

        return StatusCode(StatusCodes.Status201Created, response);
    }
}