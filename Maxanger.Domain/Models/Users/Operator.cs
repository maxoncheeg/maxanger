using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Domain.Models.Users;

public class Operator : IOperator
{
    public long Id { get; init; }
    public string Username { get; init; }
}