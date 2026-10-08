namespace Maxanger.Domain.Validators.Messages;

public interface IMessageValidator
{
    public bool Validate(IDictionary<string, object> metadata);
}