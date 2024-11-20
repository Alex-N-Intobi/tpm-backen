namespace IBKS.Repositories.Base.Paging;

public interface IPageable<T> : IPageable
{
    new IList<T> Data { get; set; }
}
