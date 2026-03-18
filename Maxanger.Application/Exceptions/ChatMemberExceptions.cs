namespace Maxanger.Application.Exceptions;

public class ChatMemberExceptions(string code) : Exception(code);

public class UserNotChatMemberException() : ChatMemberExceptions("USER_NOT_CHAT_MEMBER");
public class MutedChatMemberException() : ChatMemberExceptions("MUTED_CHAT_MEMBER");
public class BannedChatMemberException() : ChatMemberExceptions("BANNED_CHAT_MEMBER");