using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Api.Models.Messages;
using Maxanger.Application.CQRS.Commands.Messages;
using Maxanger.Application.CQRS.Queries.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class ChatController(IMediator mediator) : AbstractController
{
    [HttpPost(MaxangerRoutes.Chat.SendMessage)]
    public async Task<IActionResult> SendMessage([FromBody] MessageOnSend message)
    {
        long userId = 1;

        var sendedMessage = await mediator.Send(new SendMessageCommand(userId, message.ChatId, message.Content,
            message.MessageType, message.Metadata, message.ReplyToId));

        return StatusCode(StatusCodes.Status201Created, sendedMessage);
    }

    [HttpGet(MaxangerRoutes.Chat.Base)]
    public async Task<IActionResult> GetMessagesAsync(long chatId, int take = 50, int page = 0)
    {
        long userId = 1;
        var messages = await mediator.Send(new GetMessagesQuery(chatId, userId) { Take = take, Page = page });


        return StatusCode(StatusCodes.Status201Created, messages);
    }


    [HttpPost(MaxangerRoutes.Chat.WhisperMessage)]
    public IActionResult WhisperMessage(int chatId, string username, string toUsername, string message)
    {
        return BaseResponse(StatusCodes.Status201Created);
    }
}