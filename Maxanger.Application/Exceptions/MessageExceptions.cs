namespace Maxanger.Application.Exceptions;

public class MessageException(string code) : Exception(code);

public class MessageNotSendException() : MessageException("MESSAGE_NOT_SEND");