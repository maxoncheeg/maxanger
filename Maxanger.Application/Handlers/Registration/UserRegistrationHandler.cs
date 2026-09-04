using System.Transactions;
using Maxanger.Application.CQRS.Commands.Register;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Domain.Services.AccessTickets;
using Maxanger.Domain.Services.Users;
using MediatR;

namespace Maxanger.Application.Handlers.Registration;

public class UserRegistrationHandler(
    IUserRegistrationService userRegistrationService,
    IAccessTicketService accessTicketService) : IRequestHandler<RegisterUserWithCodeCommand, UserDto>
{
    public async Task<UserDto> Handle(RegisterUserWithCodeCommand request, CancellationToken cancellationToken)
    {
        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        
        await accessTicketService.UseAccessTicketCodeAsync(request.Code, cancellationToken);
        
        var user = await userRegistrationService.RegisterUser(request.Username, request.Email, request.Password, cancellationToken);
        
        transaction.Complete();
        
        return new UserDto(user.Id, user.Username, user.Email);
    }
}