using System.Text.RegularExpressions;
using Maxanger.Domain.Entities.Abstract;
using Maxanger.Domain.Entities.Chats;
using Maxanger.Domain.Entities.Messages;
using Maxanger.Domain.Entities.Messages.Polls;
using Maxanger.Domain.Exceptions;

namespace Maxanger.Domain.Entities.Users;

public class User : IEntity
{
    public long Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public DateTime RegistrationDate { get; private set; }

    public static User Create(string username, string email, string passwordHash)
    {
        if (username.Length < 3 || username.Length > 20)
            throw new DomainException("USERNAME_LENGTH", "Username must be between 3 and 20 characters long");

        if (!Regex.IsMatch(
                email,
                @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"
            ))
            throw new DomainException("INVALID_EMAIL", "Email is invalid");

        return new User
        {
            Username = username,
            Email = email,
            RegistrationDate = DateTime.UtcNow,
            UserCredentials = UserCredentials.Create(passwordHash)
        };
    }

    public IList<ChatMember> ChatMembers { get; init; } = [];
    public IList<Message> ChatMessages { get; init; } = [];
    public IList<PollVote> PollVotes { get; init; } = [];
    public UserCredentials UserCredentials { get; private set; } = null!;
}