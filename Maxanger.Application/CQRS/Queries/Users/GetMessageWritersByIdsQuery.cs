using Maxanger.Application.CQRS.Responses.Users;
using MediatR;

namespace Maxanger.Application.CQRS.Queries.Users;

public record GetMessageWritersByIdsQuery(IList<long> Ids) : IRequest<IList<MessageWriterResponse>>;