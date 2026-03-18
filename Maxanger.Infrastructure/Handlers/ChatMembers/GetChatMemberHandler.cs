using Maxanger.Application.CQRS.Queries.ChatMembers;
using Maxanger.Infrastructure.Contexts.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maxanger.Infrastructure.Handlers.ChatMembers;

public class GetChatMemberHandler(IApplicationDbContext context)
    : IRequestHandler<GetChatMemberInfoByUserIdQuery, GetChatMemberInfoByUserIdResponse?>
{
    public async Task<GetChatMemberInfoByUserIdResponse?> Handle(GetChatMemberInfoByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var member = await context.ChatMembers
            .Where(m => m.UserId == request.UserId && m.ChatId == request.ChatId)
            .Select(m => new GetChatMemberInfoByUserIdResponse(m.Status, m.Role))
            .FirstOrDefaultAsync(cancellationToken);
        
        return member;
    }
}