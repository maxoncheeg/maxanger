using Maxanger.Application.CQRS.Responses.Chats;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.Chats;

public record GetChatsInfoQuery(long UserId, DateTime LastUpdatedTime) : PagedQuery, IRequest<IList<ChatInfoResponse>>;