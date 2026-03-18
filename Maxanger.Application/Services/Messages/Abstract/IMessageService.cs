using Maxanger.Application.Models.Messages.Abstract;

namespace Maxanger.Application.Services.Messages.Abstract;

public interface IMessageService
{
    public Task<IMessages> SendMessageAsync(IMessageOnSend messageOnSend);
    public Task<IMessages> GetChatMessagesAsync(long chatId, int amount = 50, int page = 0);
}