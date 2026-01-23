using Maxanger.Application.Hubs.Abstract;
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

public class SendMessageCommandExecutor(IMessenger chat) : ICommandExecutor
{
    public CommandAction Action => CommandAction.SendMessage;

    public async Task<IExecutionResult> ExecuteAsync(IOperator @operator, IList<string>? arguments = null,
        IEnvironments? environments = null, IList<string>? modifiers = null)
    {
        string? text = arguments?[0];

        if (string.IsNullOrWhiteSpace(text))
            throw new ApplicationException("Chat name is required");

        chat.Chats.First(c => c.Id == 1).Messages.Add(new Message()
        {
            Text = text,
            Chat = chat.Chats.First(c => c.Id == 1),
            From = @operator,
        });
        
        Console.WriteLine(text);

        return new ExecutionResult() { Data = new { Id = 0, MessageId = 0 } };
    }
}