using Maxanger.Application.CQRS.Responses.Messages;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.Messages;

public record GetMessagesByIdsQuery(IList<long> MessageIds) : IRequest<IList<MessageResponse>>;