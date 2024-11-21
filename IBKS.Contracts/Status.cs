using IBKS.Contracts.Base;

namespace IBKS.Contracts;

public class Status : ContractBase<int>
{
    public string Title { get; set; }
}
