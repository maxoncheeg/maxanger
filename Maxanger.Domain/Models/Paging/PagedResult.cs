namespace Maxanger.Domain.Models.Paging;

public record PagedResult<T>(Paging Paging, IReadOnlyList<T> Results);