namespace Maxanger.Application.Exceptions;

public class AuthenticationException(string code) : Exception(code);


public class UserNotFoundException() : AuthenticationException("USER_NOT_FOUND");
public class UserIdNotFoundException() : AuthenticationException("USER_ID_NOT_FOUND");