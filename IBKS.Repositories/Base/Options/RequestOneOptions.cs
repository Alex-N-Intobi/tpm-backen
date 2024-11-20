namespace IBKS.Repositories.Base.Options;

public class RequestOneOptions
{
    public string Include { get; set; }

    public List<string> IncludeProperties => Include?.Split(",")?.Select(x => x.Trim()).ToList() ?? [];
}
