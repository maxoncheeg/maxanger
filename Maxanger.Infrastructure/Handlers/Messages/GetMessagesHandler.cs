using Maxanger.Application.CQRS.Queries.Messages;
using Maxanger.Application.CQRS.Responses.Messages;
using Maxanger.Infrastructure.Contexts.Abstract;
using Maxanger.Infrastructure.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Handlers.Messages;

public class GetMessagesHandler(IApplicationDbContext context) : 
    IRequestHandler<GetMessagesByIdsQuery, IList<MessageResponse>>,
    IRequestHandler<GetMessagesQuery, IList<MessageResponse>>
{
    public async Task<IList<MessageResponse>> Handle(GetMessagesByIdsQuery request, CancellationToken cancellationToken)
    {
        var messages = await context.Messages
            .OrderByDescending(m => m.Id)
            .Where(m => request.MessageIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        return [..messages.Select(m => m.ToMessageResponse())];
    }

    public async Task<IList<MessageResponse>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await context.Messages
            .OrderByDescending(m => m.Id)
            .Where(m => m.ChatId == request.ChatId && m.FromId == request.UserId)
            .Take(request.Take)
            .Skip(request.Page * request.Take)
            .ToListAsync(cancellationToken);

        return [..messages.Select(m => m.ToMessageResponse())];
    }
}