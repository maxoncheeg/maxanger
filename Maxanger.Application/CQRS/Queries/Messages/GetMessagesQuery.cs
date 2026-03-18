using Maxanger.Application.CQRS.Responses.Messages;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.Messages;

public record GetMessagesQuery(long ChatId, long UserId) : PagedQuery, IRequest<IList<MessageResponse>>;