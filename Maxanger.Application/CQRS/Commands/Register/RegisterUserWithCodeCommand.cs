using Maxanger.Application.CQRS.Responses.Users;
using MediatR;

namespace Maxanger.Application.CQRS.Commands.Register;

public record RegisterUserWithCodeCommand(string Username, string Email, string Password, string Code) : IRequest<UserDto>;