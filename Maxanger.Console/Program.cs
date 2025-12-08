// See https://aka.ms/new-console-template for more information

using Maxanger.Application.CommandExecutors;
using Maxanger.Domain.Interpreters;
using Maxanger.Domain.Interpreters.Abstract;
using Maxanger.Domain.Messengers;
using Maxanger.Domain.Messengers.Abstract;
using Maxanger.Domain.Models.Users;
using Maxanger.Domain.Models.Users.Abstract;
using Maxanger.Domain.Parsers;
using Maxanger.Domain.Parsers.Abstract;
using Maxanger.Domain.Parsers.CommandBases;
using Maxanger.Domain.Parsers.CommandParseHandlers;
using Maxanger.Domain.Shells;
using Maxanger.Domain.Shells.Abstract;

long chatId = 0;

IMessenger messenger = new Messenger();
messenger.NewChat += (id) => chatId = id;

ICommandAnalyzer commandAnalyzer = new CommandAnalyzer([
    new CreateChatCommandBase(),
    new SendMessageCommandBase()
]);

ICommandParseHandlerFactory commandParseHandlerFactory = new CommandParseHandlerFactory([
    new CreateChatCommandParseHandler(),
    new SendMessageCommandParseHandler()
]);

ICommandExecutorFactory commandExecutorFactory = new CommandExecutorFactory([
    new CreateChatCommandExecutor(messenger),
    new SendMessageCommandExecutor(messenger)
]);

ICommandParser parser = new CommandParser(commandAnalyzer, commandParseHandlerFactory);
ICommandInterpreter interpreter = new CommandInterpreter(commandExecutorFactory);

ICommandShell shell = new CommandShell(parser, interpreter);

IOperator operator1 = new Operator() { Id = 1, Username = "jordan" };
IOperator operator2 = new Operator() { Id = 2, Username = "aboba" };

shell.Invoke(operator1, "/chat create MEGACHAT");
shell.Invoke(operator1, $"/m {chatId} hello");
shell.Invoke(operator2, $"/m {chatId} hi");

foreach (var chat in messenger.Chats)
{
    Console.WriteLine("ЧАТ: " + chat.Name + "\n");
    
    foreach (var message in chat.Messages)
    {
        Console.WriteLine($"{message.Date.ToLongTimeString()} {message.From.Username} : {message.Text}");
    }
    
    Console.WriteLine("\n\n");
}

