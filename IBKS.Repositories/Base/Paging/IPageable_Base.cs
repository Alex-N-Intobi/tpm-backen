namespace IBKS.Repositories.Base.Paging;

public interface IPageable
{
    List<object> Data { get; }

    int Count { get; }

    int TotalCount { get; set; }
}
