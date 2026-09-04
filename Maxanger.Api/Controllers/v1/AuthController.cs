using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Maxanger.Application.CQRS.Commands.AccessTickets;
using Maxanger.Application.CQRS.Commands.Register;
using Maxanger.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1.0)]
public class AuthController(IMediator mediator) : AbstractController
{
    [HttpPost(MaxangerRoutes.Auth.Register)]
    public async Task<IActionResult> RegisterAsync(string code, string username, string email)
    {
        var user = await mediator.Send(new RegisterUserWithCodeCommand(username, email, "123", code));

        return BaseResponse(StatusCodes.Status200OK, user);
    }

    [HttpPost(MaxangerRoutes.Auth.Ticket)]
    public async Task<IActionResult> CreateTicket(string code)
    {
        var id = await mediator.Send(new CreateAccessTicketCommand(code, DateTime.UtcNow.AddYears(2),
            AccessTicketType.Single, true));

        return BaseResponse(StatusCodes.Status200OK, id);
    }
}