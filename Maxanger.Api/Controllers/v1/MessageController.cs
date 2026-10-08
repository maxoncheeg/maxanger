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
public class MessageController(IMediator mediator) : AbstractController
{
    [HttpPost(MaxangerRoutes.Messages.Base)]
    public async Task<IActionResult> SendMessage([FromBody] MessageOnSend message)
    {
        long userId = 1;

        var messageId = await mediator.Send(new SendMessageCommand(userId, message.ChatId, message.Content,
            message.MessageType, message.Metadata, message.ReplyToId));

        return StatusCode(StatusCodes.Status201Created, messageId);
    }

    [HttpGet(MaxangerRoutes.Messages.Base)]
    public async Task<IActionResult> SendMessage(long chatId, int page, int pageSize)
    {
        long userId = 1;

        var messages = await mediator.Send(new GetMessagesQuery(chatId, userId) { Take = pageSize, Page = page });

        return StatusCode(StatusCodes.Status201Created, messages);
    }
}