using Maxanger.Domain.Enums;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Messengers.Abstract;
using Maxanger.Domain.Models.Chats;
using Maxanger.Domain.Models.Chats.Abstract;
using Maxanger.Domain.Models.Interpreters;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Messages;
using Maxanger.Domain.Models.Messages.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Application.CommandExecutors;

public class SendMessageCommandExecutor(IMessenger messenger) : ICommandExecutor
{
    public CommandAction Action => CommandAction.SendMessage;

    public IExecutionResult Execute(IOperator @operator, IList<string>? arguments = null, IList<string>? modifiers = null)
    {
        long chatId = long.Parse(arguments?[0] ?? "-1");
        string text = arguments?[1] ?? string.Empty;

        if (string.IsNullOrWhiteSpace(text))
            throw new ApplicationException("Chat name is required");
        
        if (chatId < 0)
            throw new ApplicationException("Chat id is required");

        var chat = messenger.Chats.FirstOrDefault(chat => chat.Id == chatId);
        
        if (chat == null)
            throw new ApplicationException("Chat not found");
        
        IMessage message = new Message() {Chat = chat, From = @operator, Text = text};
        
        chat.Messages.Add(message);

        return new ExecutionResult() { Data = new { Id = chat.Id, MessageId = 0 } };
    }
}