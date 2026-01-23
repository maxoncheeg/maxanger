using Maxanger.Domain.Enums;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Messengers.Abstract;
using Maxanger.Domain.Models.Chats;
using Maxanger.Domain.Models.Chats.Abstract;
using Maxanger.Domain.Models.Interpreters;
using Maxanger.Domain.Models.Interpreters.Abstract;
using Maxanger.Domain.Models.Users.Abstract;

namespace Maxanger.Application.CommandExecutors;

public class CreateChatCommandExecutor(IMessenger messenger) : ICommandExecutor
{
    public CommandAction Action => CommandAction.ChatCreate;

    public async Task<IExecutionResult> ExecuteAsync(IOperator @operator, IList<string>? arguments = null, IEnvironments? environments = null, IList<string>? modifiers = null)
    {
        long id = messenger.Chats.Count > 0 ? messenger.Chats.Last().Id : 0;

        IChat chat = new Chat { Name = "chatName", Id = id + 1, Messages = [] };
        messenger.AddChat(chat);
        
        // уведомить кого нужэно

        return new ExecutionResult() { Data = new { Id = chat.Id, Name = chat.Name } };
    }
}