using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class InstalledEnvironment : ContractBase<int>
{
    public string Title { get; set; }
}
