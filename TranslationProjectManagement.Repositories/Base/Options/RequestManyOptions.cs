namespace TranslationProjectManagement.Repositories.Base.Options;

public class RequestManyOptions : RequestOneOptions
{
    private const int _defaultLimit = int.MaxValue;

    public int Offset { get; set; }

    private int _limit;
    public int Limit
    {
        get => _limit == 0 ? _defaultLimit : _limit;
        set => _limit = value;
    }

    public string SortBy { get; set; }

    public string SortDirection { get; set; }
}
