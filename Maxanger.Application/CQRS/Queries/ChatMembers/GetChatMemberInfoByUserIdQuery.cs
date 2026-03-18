using Maxanger.Domain.Enums;
using Maxanger.Domain.Models.Users.Abstract;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.ChatMembers;

public record GetChatMemberInfoByUserIdQuery(long UserId, long ChatId) : IRequest<GetChatMemberInfoByUserIdResponse?>;

public record GetChatMemberInfoByUserIdResponse(MemberStatus Status, MemberRole Role) : IChatMember;