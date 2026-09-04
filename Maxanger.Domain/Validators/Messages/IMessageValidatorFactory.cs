using Maxanger.Domain.Enums;

namespace Maxanger.Domain.Validators.Messages;

public interface IMessageValidatorFactory
{
    public IMessageValidator Get(MessageType type);
}