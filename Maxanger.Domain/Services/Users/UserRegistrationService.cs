using Maxanger.Domain.Abstractions.Hashers;
using Maxanger.Domain.Abstractions.UnitOfWork;
using Maxanger.Domain.Entities.Users;
using Maxanger.Domain.Exceptions;
using Maxanger.Domain.Repositories.Users;
using Maxanger.Domain.Services.Validators.Password;

namespace Maxanger.Domain.Services.Users;

public class UserRegistrationService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IPasswordValidator passwordValidator,
    IUnitOfWork unitOfWork) : IUserRegistrationService
{
    public async Task<User> RegisterUser(string username, string email, string password, CancellationToken cancellationToken = default)
    {
        if(!passwordValidator.IsValid(password))
            throw new DomainException("INVALID_PASSWORD", "Password is invalid");
        
        var user = User.Create(username, email, passwordHasher.Hash(password));
        
        userRepository.CreateUser(user);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user;
    }
}