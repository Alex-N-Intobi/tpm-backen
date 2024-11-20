namespace IBKS.Repositories.Base.Paging;

public class Pageable<T> : IPageable<T>
{
    public Pageable() : this(Array.Empty<T>(), 0)
    {
    }

    public Pageable(IList<T> data, int totalCount)
    {
        TotalCount = totalCount;
        Data = data;
    }

    public IList<T> Data { get; set; }

    List<object> IPageable.Data => Data.Cast<object>().ToList();

    public int TotalCount { get; set; }


    private int _count;
    public int Count
    {
        get => Data?.Count ?? 0;
        set => _count = value;
    }
}
