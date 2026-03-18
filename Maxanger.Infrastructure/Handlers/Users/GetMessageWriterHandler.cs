using Maxanger.Application.CQRS.Queries.Users;
using Maxanger.Application.CQRS.Responses.Users;
using Maxanger.Infrastructure.Contexts.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Handlers.Users;

public class GetMessageWriterHandler(IApplicationDbContext context)
    : IRequestHandler<GetMessageWritersByIdsQuery, IList<MessageWriterResponse>>
{
    public async Task<IList<MessageWriterResponse>> Handle(GetMessageWritersByIdsQuery request,
        CancellationToken cancellationToken)
    {
        return await context.Users.Where(u => request.Ids.Contains(u.Id))
            .Select(u => new MessageWriterResponse(u.Id, u.Username)).ToListAsync(cancellationToken);
    }
}