using Maxanger.Application.CQRS.Queries.Messages;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Application.Mappers;
using Maxanger.Domain.Services.Messages;
using MediatR;

namespace Maxanger.Application.Handlers.Messages;

public class GetMessagesHandler(IGetMessagesService getMessagesService)
    : IRequestHandler<GetMessagesQuery, IList<MessageDto>>
{
    public async Task<IList<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var result = await getMessagesService.GetMessagesAsync(request.ChatId, request.UserId,
            request.Page * request.Take,
            request.Take, cancellationToken);

        return [.. result.Select(message => message.ToMessageDto())];
    }
}