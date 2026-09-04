namespace Maxanger.Domain.Factories.Messages;

// public class MessageFactory(IMessageValidatorFactory messageValidatorFactory) : IMessageFactory
// {
//     public Message Create(MessageType type, string content, long fromId, Dictionary<string, object>? metadata, long? replyToMessageId)
//     {
//         if (string.IsNullOrEmpty(content))
//             throw new DomainException("EMPTY_CONTENT", "Empty content");
//
//         if (metadata != null)
//         {
//             var validator = messageValidatorFactory.Get(type);
//             if (!validator.Validate(metadata))
//             {
//                 throw new DomainException("INVALID_METADATA", "Invalid metadata");
//             }
//         }
//
//         return new Message
//         {
//             Type = type,
//             Content = content,
//             FromId = fromId,
//             Metadata = metadata,
//             ReplyToMessageId = replyToMessageId
//         };
//     }
// }