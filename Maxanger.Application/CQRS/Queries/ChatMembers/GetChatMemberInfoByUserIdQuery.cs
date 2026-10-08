using Maxanger.Domain.Enums;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.ChatMembers;

public record GetChatMemberInfoByUserIdQuery(long UserId, long ChatId) : IRequest<GetChatMemberInfoByUserIdResponse?>;

public record GetChatMemberInfoByUserIdResponse(MemberStatus Status, MemberRole Role) ;