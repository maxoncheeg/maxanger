using Maxanger.Application.Models.Users.Abstract;

namespace Maxanger.Application.CQRS.Responses.Users;

public record MessageWriterResponse(long Id, string Username) : IMessageWriter;