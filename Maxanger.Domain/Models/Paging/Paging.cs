namespace Maxanger.Domain.Models.Paging;

public record Paging(int Skip, int Take)
{
    public static Paging FromPageAndSize(int page, int pageSize)
        => new(pageSize * page, page);
}